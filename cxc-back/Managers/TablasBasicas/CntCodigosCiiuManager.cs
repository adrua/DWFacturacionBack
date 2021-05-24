//CntCodigosCiiuManager.cs
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Cxc.TablasBasicas.Interfaces;
using Cxc.TablasBasicas.Models;

namespace Cxc.TablasBasicas.Managers
{
    public class CntCodigosCiiuManager : ICntCodigosCiiuManager
	{	
        private readonly ILogger<CntCodigosCiiuManager> logger;
        private readonly CntContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userId;

        public CntCodigosCiiuManager(ILogger<CntCodigosCiiuManager> logger,
                                CntContext context,
                                IHttpContextAccessor httpContextAccessor)
        {
            this.logger = logger;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            //this.userId = ApplicationUserTokenHelper.GetIdFromAuthorization(httpContextAccessor.HttpContext.Request);
        }

        IQueryable<CntCodigosCiiu> ICntCodigosCiiuManager.GetAll()
        {
            // Obtenemos el nombre del método para logging
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            IQueryable<CntCodigosCiiu> result = null;
            
            try
            {
                // Loggeamos el inicio de la operación
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                // obtenemos los datos como IQueryable para optimizar oData
                result = context.CntCodigosCiiu;
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

        CntCodigosCiiu ICntCodigosCiiuManager.GetById(string keyCodigoCiiuId)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            
            CntCodigosCiiu result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntCodigosCiiu.Where((x) => x.CodigoCiiuId == keyCodigoCiiuId).FirstOrDefault();
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

        CntCodigosCiiu ICntCodigosCiiuManager.Add(CntCodigosCiiu row)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntCodigosCiiu result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntCodigosCiiu.Where((x) => x.CodigoCiiuId == row.CodigoCiiuId).FirstOrDefault();
                
                if (result == null)
                {   
                    result = row;
                    
                    context.Entry(row).Property("Usuario").CurrentValue = userId;
                    context.CntCodigosCiiu.Add(row);
                }
                else 
                {
                    logger.Log(LogLevel.Error, $"Llave Duplicada: CntCodigosCiiu({row.CodigoCiiuId})");
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
        
        CntCodigosCiiu ICntCodigosCiiuManager.Update(string keyCodigoCiiuId, Delta<CntCodigosCiiu> changes)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntCodigosCiiu result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntCodigosCiiu.Where((x) => x.CodigoCiiuId == keyCodigoCiiuId).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: CntCodigosCiiu({keyCodigoCiiuId})");
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

        CntCodigosCiiu ICntCodigosCiiuManager.Delete(string keyCodigoCiiuId)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntCodigosCiiu result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntCodigosCiiu.Where((x) => x.CodigoCiiuId == keyCodigoCiiuId).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: CntCodigosCiiu({keyCodigoCiiuId})");
                    return null;
                }
                else 
                {
                    context.CntCodigosCiiu.Remove(result);
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
       
        int ICntCodigosCiiuManager.SaveChanges()
        {
            return context.SaveChanges();
        }
	}
}