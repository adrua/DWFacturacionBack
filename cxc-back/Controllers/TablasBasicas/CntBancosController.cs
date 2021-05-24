//CntBancosController.cs
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
    public class CntBancosController : ODataController
	{	
        private readonly ILogger<CntBancosController> logger;
        private readonly ICntBancosManager CntBancosManager;

        public CntBancosController(ILogger<CntBancosController> logger,
                                    ICntBancosManager CntBancosManager)
        {
            this.logger = logger;
            this.CntBancosManager = CntBancosManager;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get(CancellationToken token)
        {
            logger.Log(LogLevel.Information, $"Inicio de consumo del API: {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return Ok(this.CntBancosManager.GetAll());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CntBancos row, CancellationToken token)
        {
        
            var orgrow = this.CntBancosManager.Add(row);
            if (orgrow == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                return BadRequest($"Llave primaria duplicada ({row.BancoId})");
            }
            else
            {
                this.CntBancosManager.SaveChanges();
                return Created(row);
            }
        }

        [HttpPatch]
        public IActionResult Patch(int keyBancoId, Delta<CntBancos> changes)
        {
            var row = this.CntBancosManager.Update(keyBancoId, changes);
            if (row == null)
            {
                return BadRequest($"Error actualizando, Fila no existe.");
            }
            else
            {
                this.CntBancosManager.SaveChanges();
                return Updated(row);
            }
        }

        [HttpDelete("CntBancos(BancoId={keyBancoId})")]
        public IActionResult Delete(int keyBancoId)
        {
            var row = this.CntBancosManager.Delete(keyBancoId);
            if (row == null)
            {
                return BadRequest($"Error eliminando, Fila no existe.");
            }
            else
            {
                this.CntBancosManager.SaveChanges();
                return Ok();
            }
        }
    }
}
