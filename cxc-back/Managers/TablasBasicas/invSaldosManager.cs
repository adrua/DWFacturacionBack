//invSaldosManager.cs
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
    public class invSaldosManager : IinvSaldosManager
	{	
        private readonly ILogger<invSaldosManager> logger;
        private readonly CntContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userId;

        public invSaldosManager(ILogger<invSaldosManager> logger,
                                CntContext context,
                                IHttpContextAccessor httpContextAccessor)
        {
            this.logger = logger;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            //this.userId = ApplicationUserTokenHelper.GetIdFromAuthorization(httpContextAccessor.HttpContext.Request);
        }

        IQueryable<invSaldos> IinvSaldosManager.GetAll()
        {
            // Obtenemos el nombre del método para logging
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            IQueryable<invSaldos> result = null;
            
            try
            {
                // Loggeamos el inicio de la operación
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                // obtenemos los datos como IQueryable para optimizar oData
                result = context.invSaldos;
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

        invSaldos IinvSaldosManager.GetById(string keyProductoLinea, string keyPeriodoDescripcionx)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            
            invSaldos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.invSaldos.Where((x) => x.ProductoLinea == keyProductoLinea && x.PeriodoDescripcionx == keyPeriodoDescripcionx).FirstOrDefault();
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

        invSaldos IinvSaldosManager.Add(invSaldos row)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            invSaldos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.invSaldos.Where((x) => x.ProductoLinea == row.ProductoLinea && x.PeriodoDescripcionx == row.PeriodoDescripcionx).FirstOrDefault();
                
                if (result == null)
                {   
                    result = row;
                    
                    context.Entry(row).Property("Usuario").CurrentValue = userId;
                    context.invSaldos.Add(row);
                }
                else 
                {
                    logger.Log(LogLevel.Error, $"Llave Duplicada: invSaldos({row.ProductoLinea}, {row.PeriodoDescripcionx})");
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
        
        invSaldos IinvSaldosManager.Update(string keyProductoLinea, string keyPeriodoDescripcionx, Delta<invSaldos> changes)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            invSaldos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.invSaldos.Where((x) => x.ProductoLinea == keyProductoLinea && x.PeriodoDescripcionx == keyPeriodoDescripcionx).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: invSaldos({keyProductoLinea}, {keyPeriodoDescripcionx})");
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

        invSaldos IinvSaldosManager.Delete(string keyProductoLinea, string keyPeriodoDescripcionx)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            invSaldos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.invSaldos.Where((x) => x.ProductoLinea == keyProductoLinea && x.PeriodoDescripcionx == keyPeriodoDescripcionx).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: invSaldos({keyProductoLinea}, {keyPeriodoDescripcionx})");
                    return null;
                }
                else 
                {
                    context.invSaldos.Remove(result);
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
       
        int IinvSaldosManager.SaveChanges()
        {
            return context.SaveChanges();
        }
	}
}