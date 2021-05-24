//CntClientesController.cs
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

using Microsoft.Extensions.Logging;

using Cxc.TablasBasicas.Interfaces;
using Cxc.TablasBasicas.Models;

namespace Cxc.TablasBasicas.DataLayer.Models
{
    //[Authorize(Policy = "Bearer")]
    public class CntClientesController : ODataController
	{	
        private readonly ILogger<CntClientesController> logger;
        private readonly ICntClientesManager CntClientesManager;

        public CntClientesController(ILogger<CntClientesController> logger,
                                    ICntClientesManager CntClientesManager)
        {
            this.logger = logger;
            this.CntClientesManager = CntClientesManager;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get(CancellationToken token)
        {
            logger.Log(LogLevel.Information, $"Inicio de consumo del API: {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return Ok(this.CntClientesManager.GetAll());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CntClientes row, CancellationToken token)
        {
        
            var orgrow = this.CntClientesManager.Add(row);
            if (orgrow == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                return BadRequest($"Llave primaria duplicada ({row.ClienteId})");
            }
            else
            {
                this.CntClientesManager.SaveChanges();
                return Created(row);
            }
        }

        [HttpPatch]
        public IActionResult Patch(decimal keyClienteId, Delta<CntClientes> changes)
        {
            var row = this.CntClientesManager.Update(keyClienteId, changes);
            if (row == null)
            {
                return BadRequest($"Error actualizando, Fila no existe.");
            }
            else
            {
                this.CntClientesManager.SaveChanges();
                return Updated(row);
            }
        }

        [HttpDelete("CntClientes(ClienteId={keyClienteId})")]
        public IActionResult Delete(decimal keyClienteId)
        {
            var row = this.CntClientesManager.Delete(keyClienteId);
            if (row == null)
            {
                return BadRequest($"Error eliminando, Fila no existe.");
            }
            else
            {
                this.CntClientesManager.SaveChanges();
                return Ok();
            }
        }
    }
}
