//CntCodigosCiiuController.cs
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
    public class CntCodigosCiiuController : ODataController
	{	
        private readonly ILogger<CntCodigosCiiuController> logger;
        private readonly ICntCodigosCiiuManager CntCodigosCiiuManager;

        public CntCodigosCiiuController(ILogger<CntCodigosCiiuController> logger,
                                    ICntCodigosCiiuManager CntCodigosCiiuManager)
        {
            this.logger = logger;
            this.CntCodigosCiiuManager = CntCodigosCiiuManager;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get(CancellationToken token)
        {
            logger.Log(LogLevel.Information, $"Inicio de consumo del API: {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return Ok(this.CntCodigosCiiuManager.GetAll());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CntCodigosCiiu row, CancellationToken token)
        {
        
            var orgrow = this.CntCodigosCiiuManager.Add(row);
            if (orgrow == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                return BadRequest($"Llave primaria duplicada ({row.CodigoCiiuId})");
            }
            else
            {
                this.CntCodigosCiiuManager.SaveChanges();
                return Created(row);
            }
        }

        [HttpPatch]
        public IActionResult Patch(string keyCodigoCiiuId, Delta<CntCodigosCiiu> changes)
        {
            var row = this.CntCodigosCiiuManager.Update(keyCodigoCiiuId, changes);
            if (row == null)
            {
                return BadRequest($"Error actualizando, Fila no existe.");
            }
            else
            {
                this.CntCodigosCiiuManager.SaveChanges();
                return Updated(row);
            }
        }

        [HttpDelete("CntCodigosCiiu(CodigoCiiuId={keyCodigoCiiuId})")]
        public IActionResult Delete(string keyCodigoCiiuId)
        {
            var row = this.CntCodigosCiiuManager.Delete(keyCodigoCiiuId);
            if (row == null)
            {
                return BadRequest($"Error eliminando, Fila no existe.");
            }
            else
            {
                this.CntCodigosCiiuManager.SaveChanges();
                return Ok();
            }
        }
    }
}
