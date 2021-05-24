//invSaldosController.cs
using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

using Microsoft.Extensions.Logging;

using Cxc.TablasBasicas.Interfaces;
using Cxc.TablasBasicas.Models;

namespace Cxc.TablasBasicas.DataLayer.Models
{
    //[Authorize(Policy = "Bearer")]
    public class invSaldosController : ODataController
	{	
        private readonly ILogger<invSaldosController> logger;
        private readonly IinvSaldosManager invSaldosManager;

        public invSaldosController(ILogger<invSaldosController> logger,
                                    IinvSaldosManager invSaldosManager)
        {
            this.logger = logger;
            this.invSaldosManager = invSaldosManager;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get(CancellationToken token)
        {
            logger.Log(LogLevel.Information, $"Inicio de consumo del API: {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return Ok(this.invSaldosManager.GetAll());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] invSaldos row, CancellationToken token)
        {
        
            var orgrow = this.invSaldosManager.Add(row);
            if (orgrow == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                return BadRequest($"Llave primaria duplicada ({row.ProductoLinea}, {row.PeriodoDescripcionx})");
            }
            else
            {
                this.invSaldosManager.SaveChanges();
                return Created(row);
            }
        }

        [HttpPatch]
        public IActionResult Patch(string keyProductoLinea, string keyPeriodoDescripcionx, Delta<invSaldos> changes)
        {
            var row = this.invSaldosManager.Update(keyProductoLinea, keyPeriodoDescripcionx, changes);
            if (row == null)
            {
                return BadRequest($"Error actualizando, Fila no existe.");
            }
            else
            {
                this.invSaldosManager.SaveChanges();
                return Updated(row);
            }
        }

        [HttpDelete("invSaldos(ProductoLinea={keyProductoLinea}, PeriodoDescripcionx={keyPeriodoDescripcionx})")]
        public IActionResult Delete(string keyProductoLinea, string keyPeriodoDescripcionx)
        {
            var row = this.invSaldosManager.Delete(keyProductoLinea, keyPeriodoDescripcionx);
            if (row == null)
            {
                return BadRequest($"Error eliminando, Fila no existe.");
            }
            else
            {
                this.invSaldosManager.SaveChanges();
                return Ok();
            }
        }
    }
}
