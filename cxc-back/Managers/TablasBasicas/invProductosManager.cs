//invProductosManager.cs
using System;
using System.Linq;

using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Cxc.TablasBasicas.Interfaces;
using Cxc.TablasBasicas.Models;

namespace Cxc.TablasBasicas.Managers
{
    public class invProductosManager : IinvProductosManager
	{	
        private readonly ILogger<invProductosManager> logger;
        private readonly CntContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userId;

        public invProductosManager(ILogger<invProductosManager> logger,
                                CntContext context,
                                IHttpContextAccessor httpContextAccessor)
        {
            this.logger = logger;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            //this.userId = ApplicationUserTokenHelper.GetIdFromAuthorization(httpContextAccessor.HttpContext.Request);
        }

        IQueryable<invProductos> IinvProductosManager.GetAll()
        {
            // Obtenemos el nombre del método para logging
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            IQueryable<invProductos> result = null;
            
            try
            {
                // Loggeamos el inicio de la operación
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                // obtenemos los datos como IQueryable para optimizar oData
                result = context.invProductos;
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

        invProductos IinvProductosManager.GetById(string keyProductoLinea)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            
            invProductos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.invProductos.Where((x) => x.ProductoLinea == keyProductoLinea).FirstOrDefault();
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

        invProductos IinvProductosManager.Add(invProductos row)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            invProductos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.invProductos.Where((x) => x.ProductoLinea == row.ProductoLinea).FirstOrDefault();
                
                if (result == null)
                {   
                    result = row;
                    
                    context.Entry(row).Property("Usuario").CurrentValue = userId;
                    context.invProductos.Add(row);
                }
                else 
                {
                    logger.Log(LogLevel.Error, $"Llave Duplicada: invProductos({row.ProductoLinea})");
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
        
        invProductos IinvProductosManager.Update(string keyProductoLinea, Delta<invProductos> changes)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            invProductos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.invProductos.Where((x) => x.ProductoLinea == keyProductoLinea).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: invProductos({keyProductoLinea})");
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

        invProductos IinvProductosManager.Delete(string keyProductoLinea)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            invProductos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.invProductos.Where((x) => x.ProductoLinea == keyProductoLinea).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: invProductos({keyProductoLinea})");
                    return null;
                }
                else 
                {
                    context.invProductos.Remove(result);
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
       
        int IinvProductosManager.SaveChanges()
        {
            return context.SaveChanges();
        }
	}
}