//CntFacturasController.cs
using System.Threading;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

using Microsoft.Extensions.Logging;

using Cxc.Procesos.Interfaces;
using Cxc.Procesos.Models;

namespace Cxc.Procesos.DataLayer.Models
{
    //[Authorize(Policy = "Bearer")]
    public class CntFacturasController : ODataController
	{	
        private readonly ILogger<CntFacturasController> logger;
        private readonly ICntFacturasManager CntFacturasManager;

        public CntFacturasController(ILogger<CntFacturasController> logger,
                                    ICntFacturasManager CntFacturasManager)
        {
            this.logger = logger;
            this.CntFacturasManager = CntFacturasManager;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get(CancellationToken token)
        {
            logger.Log(LogLevel.Information, $"Inicio de consumo del API: {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return Ok(this.CntFacturasManager.GetAll());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CntFacturas row, CancellationToken token)
        {
        
            var orgrow = this.CntFacturasManager.Add(row);
            if (orgrow == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                return BadRequest($"Llave primaria duplicada ({row.FacturaId}, {row.FacturaSerie})");
            }
            else
            {
                this.CntFacturasManager.SaveChanges();
                return Created(row);
            }
        }

        [HttpPatch]
        public IActionResult Patch(int keyFacturaId, int keyFacturaSerie, Delta<CntFacturas> changes)
        {
            var row = this.CntFacturasManager.Update(keyFacturaId, keyFacturaSerie, changes);
            if (row == null)
            {
                return BadRequest($"Error actualizando, Fila no existe.");
            }
            else
            {
                this.CntFacturasManager.SaveChanges();
                return Updated(row);
            }
        }

        [HttpDelete("CntFacturas(FacturaId={keyFacturaId}, FacturaSerie={keyFacturaSerie})")]
        public IActionResult Delete(int keyFacturaId, int keyFacturaSerie)
        {
            var row = this.CntFacturasManager.Delete(keyFacturaId, keyFacturaSerie);
            if (row == null)
            {
                return BadRequest($"Error eliminando, Fila no existe.");
            }
            else
            {
                this.CntFacturasManager.SaveChanges();
                return Ok();
            }
        }
    }
}
