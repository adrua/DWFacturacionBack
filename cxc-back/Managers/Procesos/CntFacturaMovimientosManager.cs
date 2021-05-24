//CntFacturaMovimientosManager.cs
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Cxc.Procesos.Interfaces;
using Cxc.Procesos.Models;
using Cxc.TablasBasicas.Models;

namespace Cxc.Procesos.Managers
{
    public class CntFacturaMovimientosManager : ICntFacturaMovimientosManager
	{	
        private readonly ILogger<CntFacturaMovimientosManager> logger;
        private readonly CntContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userId;

        public CntFacturaMovimientosManager(ILogger<CntFacturaMovimientosManager> logger,
                                CntContext context,
                                IHttpContextAccessor httpContextAccessor)
        {
            this.logger = logger;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            //this.userId = ApplicationUserTokenHelper.GetIdFromAuthorization(httpContextAccessor.HttpContext.Request);
        }

        IQueryable<CntFacturaMovimientos> ICntFacturaMovimientosManager.GetAll()
        {
            // Obtenemos el nombre del método para logging
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            IQueryable<CntFacturaMovimientos> result = null;
            
            try
            {
                // Loggeamos el inicio de la operación
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                // obtenemos los datos como IQueryable para optimizar oData
                result = context.CntFacturaMovimientos;
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

        CntFacturaMovimientos ICntFacturaMovimientosManager.GetById(int keyFacturaId, int keyFacturaSerie, string keyProductoLinea)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            
            CntFacturaMovimientos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntFacturaMovimientos.Where((x) => x.FacturaId == keyFacturaId && x.FacturaSerie == keyFacturaSerie && x.ProductoLinea == keyProductoLinea).FirstOrDefault();
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

        CntFacturaMovimientos ICntFacturaMovimientosManager.Add(CntFacturaMovimientos row)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntFacturaMovimientos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntFacturaMovimientos.Where((x) => x.FacturaId == row.FacturaId && x.FacturaSerie == row.FacturaSerie && x.ProductoLinea == row.ProductoLinea).FirstOrDefault();
                
                if (result == null)
                {   
                    result = row;
                    
                    context.Entry(row).Property("Usuario").CurrentValue = userId;
                    context.CntFacturaMovimientos.Add(row);
                }
                else 
                {
                    logger.Log(LogLevel.Error, $"Llave Duplicada: CntFacturaMovimientos({row.FacturaId}, {row.FacturaSerie}, {row.ProductoLinea})");
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
        
        CntFacturaMovimientos ICntFacturaMovimientosManager.Update(int keyFacturaId, int keyFacturaSerie, string keyProductoLinea, Delta<CntFacturaMovimientos> changes)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntFacturaMovimientos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntFacturaMovimientos.Where((x) => x.FacturaId == keyFacturaId && x.FacturaSerie == keyFacturaSerie && x.ProductoLinea == keyProductoLinea).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: CntFacturaMovimientos({keyFacturaId}, {keyFacturaSerie}, {keyProductoLinea})");
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

        CntFacturaMovimientos ICntFacturaMovimientosManager.Delete(int keyFacturaId, int keyFacturaSerie, string keyProductoLinea)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntFacturaMovimientos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntFacturaMovimientos.Where((x) => x.FacturaId == keyFacturaId && x.FacturaSerie == keyFacturaSerie && x.ProductoLinea == keyProductoLinea).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: CntFacturaMovimientos({keyFacturaId}, {keyFacturaSerie}, {keyProductoLinea})");
                    return null;
                }
                else 
                {
                    context.CntFacturaMovimientos.Remove(result);
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
       
        int ICntFacturaMovimientosManager.SaveChanges()
        {
            return context.SaveChanges();
        }
	}
}