//CntCiudadesController.cs
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
    public class CntCiudadesController : ODataController
	{	
        private readonly ILogger<CntCiudadesController> logger;
        private readonly ICntCiudadesManager CntCiudadesManager;

        public CntCiudadesController(ILogger<CntCiudadesController> logger,
                                    ICntCiudadesManager CntCiudadesManager)
        {
            this.logger = logger;
            this.CntCiudadesManager = CntCiudadesManager;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get(CancellationToken token)
        {
            logger.Log(LogLevel.Information, $"Inicio de consumo del API: {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return Ok(this.CntCiudadesManager.GetAll());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CntCiudades row, CancellationToken token)
        {
        
            var orgrow = this.CntCiudadesManager.Add(row);
            if (orgrow == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                return BadRequest($"Llave primaria duplicada ({row.CiudadDepartamentoId}, {row.Ciudadid})");
            }
            else
            {
                this.CntCiudadesManager.SaveChanges();
                return Created(row);
            }
        }

        [HttpPatch]
        public IActionResult Patch(int keyCiudadDepartamentoId, int keyCiudadid, Delta<CntCiudades> changes)
        {
            var row = this.CntCiudadesManager.Update(keyCiudadDepartamentoId, keyCiudadid, changes);
            if (row == null)
            {
                return BadRequest($"Error actualizando, Fila no existe.");
            }
            else
            {
                this.CntCiudadesManager.SaveChanges();
                return Updated(row);
            }
        }

        [HttpDelete("CntCiudades(CiudadDepartamentoId={keyCiudadDepartamentoId}, Ciudadid={keyCiudadid})")]
        public IActionResult Delete(int keyCiudadDepartamentoId, int keyCiudadid)
        {
            var row = this.CntCiudadesManager.Delete(keyCiudadDepartamentoId, keyCiudadid);
            if (row == null)
            {
                return BadRequest($"Error eliminando, Fila no existe.");
            }
            else
            {
                this.CntCiudadesManager.SaveChanges();
                return Ok();
            }
        }
    }
}
