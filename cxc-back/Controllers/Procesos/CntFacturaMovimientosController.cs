//CntFacturaMovimientosController.cs
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

using Cxc.Procesos.Interfaces;
using Cxc.Procesos.Models;

namespace Cxc.Procesos.DataLayer.Models
{
    //[Authorize(Policy = "Bearer")]
    public class CntFacturaMovimientosController : ODataController
	{	
        private readonly ILogger<CntFacturaMovimientosController> logger;
        private readonly ICntFacturaMovimientosManager CntFacturaMovimientosManager;

        public CntFacturaMovimientosController(ILogger<CntFacturaMovimientosController> logger,
                                    ICntFacturaMovimientosManager CntFacturaMovimientosManager)
        {
            this.logger = logger;
            this.CntFacturaMovimientosManager = CntFacturaMovimientosManager;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get(CancellationToken token)
        {
            logger.Log(LogLevel.Information, $"Inicio de consumo del API: {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return Ok(this.CntFacturaMovimientosManager.GetAll());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CntFacturaMovimientos row, CancellationToken token)
        {
        
            var orgrow = this.CntFacturaMovimientosManager.Add(row);
            if (orgrow == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                return BadRequest($"Llave primaria duplicada ({row.FacturaId}, {row.FacturaSerie}, {row.ProductoLinea})");
            }
            else
            {
                this.CntFacturaMovimientosManager.SaveChanges();
                return Created(row);
            }
        }

        [HttpPatch]
        public IActionResult Patch(int keyFacturaId, int keyFacturaSerie, string keyProductoLinea, Delta<CntFacturaMovimientos> changes)
        {
            var row = this.CntFacturaMovimientosManager.Update(keyFacturaId, keyFacturaSerie, keyProductoLinea, changes);
            if (row == null)
            {
                return BadRequest($"Error actualizando, Fila no existe.");
            }
            else
            {
                this.CntFacturaMovimientosManager.SaveChanges();
                return Updated(row);
            }
        }

        [HttpDelete("CntFacturaMovimientos(FacturaId={keyFacturaId}, FacturaSerie={keyFacturaSerie}, ProductoLinea={keyProductoLinea})")]
        public IActionResult Delete(int keyFacturaId, int keyFacturaSerie, string keyProductoLinea)
        {
            var row = this.CntFacturaMovimientosManager.Delete(keyFacturaId, keyFacturaSerie, keyProductoLinea);
            if (row == null)
            {
                return BadRequest($"Error eliminando, Fila no existe.");
            }
            else
            {
                this.CntFacturaMovimientosManager.SaveChanges();
                return Ok();
            }
        }
    }
}
