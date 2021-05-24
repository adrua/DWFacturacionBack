//CntCiudadesManager.cs
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using Cxc.TablasBasicas.Interfaces;
using Cxc.TablasBasicas.Models;

namespace Cxc.TablasBasicas.Managers
{
    public class CntCiudadesManager : ICntCiudadesManager
	{	
        private readonly ILogger<CntCiudadesManager> logger;
        private readonly CntContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userId;

        public CntCiudadesManager(ILogger<CntCiudadesManager> logger,
                                CntContext context,
                                IHttpContextAccessor httpContextAccessor)
        {
            this.logger = logger;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            //this.userId = ApplicationUserTokenHelper.GetIdFromAuthorization(httpContextAccessor.HttpContext.Request);
        }

        IQueryable<CntCiudades> ICntCiudadesManager.GetAll()
        {
            // Obtenemos el nombre del método para logging
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            IQueryable<CntCiudades> result = null;
            
            try
            {
                // Loggeamos el inicio de la operación
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                // obtenemos los datos como IQueryable para optimizar oData
                result = context.CntCiudades;
                // retornamos la query
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, $"Error en: {methodName}\n{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                // Loggeamos el inicio de la operación
                logger.Log(LogLevel.Debug, $"Finalizada operación: {methodName}");
            }
            return result;
        }

        CntCiudades ICntCiudadesManager.GetById(int keyCiudadDepartamentoId, int keyCiudadid)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            
            CntCiudades result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntCiudades.Where((x) => x.CiudadDepartamentoId == keyCiudadDepartamentoId && x.Ciudadid == keyCiudadid).FirstOrDefault();
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, $"Error en: {methodName}\n{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                logger.Log(LogLevel.Debug, $"Finalizada operación: {methodName}");
            }
            return result;
        }

        CntCiudades ICntCiudadesManager.Add(CntCiudades row)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntCiudades result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntCiudades.Where((x) => x.CiudadDepartamentoId == row.CiudadDepartamentoId && x.Ciudadid == row.Ciudadid).FirstOrDefault();
                
                if (result == null)
                {   
                    result = row;
                    
                    context.Entry(row).Property("Usuario").CurrentValue = userId;
                    context.CntCiudades.Add(row);
                }
                else 
                {
                    logger.Log(LogLevel.Error, $"Llave Duplicada: CntCiudades({row.CiudadDepartamentoId}, {row.Ciudadid})");
                    return null;
                }
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, $"Error en: {methodName}\n{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                logger.Log(LogLevel.Debug, $"Finalizada operación: {methodName}");
            }
            return result;
        }
        
        CntCiudades ICntCiudadesManager.Update(int keyCiudadDepartamentoId, int keyCiudadid, Delta<CntCiudades> changes)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntCiudades result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntCiudades.Where((x) => x.CiudadDepartamentoId == keyCiudadDepartamentoId && x.Ciudadid == keyCiudadid).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: CntCiudades({keyCiudadDepartamentoId}, {keyCiudadid})");
                    return null;
                }
                else 
                {
                    changes.CopyChangedValues(result);

                    context.Entry(result).Property("Usuario").CurrentValue = userId;
                    context.Entry(result).Property("Fecha_Computador").CurrentValue = DateTime.Now;
                }
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, $"Error en: {methodName}\n{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                logger.Log(LogLevel.Debug, $"Finalizada operación: {methodName}");
            }
            return result;
        }

        CntCiudades ICntCiudadesManager.Delete(int keyCiudadDepartamentoId, int keyCiudadid)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntCiudades result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntCiudades.Where((x) => x.CiudadDepartamentoId == keyCiudadDepartamentoId && x.Ciudadid == keyCiudadid).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: CntCiudades({keyCiudadDepartamentoId}, {keyCiudadid})");
                    return null;
                }
                else 
                {
                    context.CntCiudades.Remove(result);
                }
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, $"Error en: {methodName}\n{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                logger.Log(LogLevel.Debug, $"Finalizada operación: {methodName}");
            }
            return result;
        }
       
        int ICntCiudadesManager.SaveChanges()
        {
            return context.SaveChanges();
        }
	}
}