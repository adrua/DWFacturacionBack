//invProductosController.cs
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
    public class invProductosController : ODataController
	{	
        private readonly ILogger<invProductosController> logger;
        private readonly IinvProductosManager invProductosManager;

        public invProductosController(ILogger<invProductosController> logger,
                                    IinvProductosManager invProductosManager)
        {
            this.logger = logger;
            this.invProductosManager = invProductosManager;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get(CancellationToken token)
        {
            logger.Log(LogLevel.Information, $"Inicio de consumo del API: {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return Ok(this.invProductosManager.GetAll());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] invProductos row, CancellationToken token)
        {
        
            var orgrow = this.invProductosManager.Add(row);
            if (orgrow == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                return BadRequest($"Llave primaria duplicada ({row.ProductoLinea})");
            }
            else
            {
                this.invProductosManager.SaveChanges();
                return Created(row);
            }
        }

        [HttpPatch]
        public IActionResult Patch(string keyProductoLinea, Delta<invProductos> changes)
        {
            var row = this.invProductosManager.Update(keyProductoLinea, changes);
            if (row == null)
            {
                return BadRequest($"Error actualizando, Fila no existe.");
            }
            else
            {
                this.invProductosManager.SaveChanges();
                return Updated(row);
            }
        }

        [HttpDelete("invProductos(ProductoLinea={keyProductoLinea})")]
        public IActionResult Delete(string keyProductoLinea)
        {
            var row = this.invProductosManager.Delete(keyProductoLinea);
            if (row == null)
            {
                return BadRequest($"Error eliminando, Fila no existe.");
            }
            else
            {
                this.invProductosManager.SaveChanges();
                return Ok();
            }
        }
    }
}
