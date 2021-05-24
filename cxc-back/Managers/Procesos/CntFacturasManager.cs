//CntFacturasManager.cs
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
    public class CntFacturasManager : ICntFacturasManager
	{	
        private readonly ILogger<CntFacturasManager> logger;
        private readonly CntContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userId;

        public CntFacturasManager(ILogger<CntFacturasManager> logger,
                                CntContext context,
                                IHttpContextAccessor httpContextAccessor)
        {
            this.logger = logger;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            //this.userId = ApplicationUserTokenHelper.GetIdFromAuthorization(httpContextAccessor.HttpContext.Request);
        }

        IQueryable<CntFacturas> ICntFacturasManager.GetAll()
        {
            // Obtenemos el nombre del método para logging
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            IQueryable<CntFacturas> result = null;
            
            try
            {
                // Loggeamos el inicio de la operación
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                // obtenemos los datos como IQueryable para optimizar oData
                result = context.CntFacturas;
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

        CntFacturas ICntFacturasManager.GetById(int keyFacturaId, int keyFacturaSerie)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            
            CntFacturas result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntFacturas.Where((x) => x.FacturaId == keyFacturaId && x.FacturaSerie == keyFacturaSerie).FirstOrDefault();
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

        CntFacturas ICntFacturasManager.Add(CntFacturas row)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntFacturas result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntFacturas.Where((x) => x.FacturaId == row.FacturaId && x.FacturaSerie == row.FacturaSerie).FirstOrDefault();
                
                if (result == null)
                {   
                    result = row;
                    
                    context.Entry(row).Property("Usuario").CurrentValue = userId;
                    context.CntFacturas.Add(row);
                }
                else 
                {
                    logger.Log(LogLevel.Error, $"Llave Duplicada: CntFacturas({row.FacturaId}, {row.FacturaSerie})");
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
        
        CntFacturas ICntFacturasManager.Update(int keyFacturaId, int keyFacturaSerie, Delta<CntFacturas> changes)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntFacturas result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntFacturas.Where((x) => x.FacturaId == keyFacturaId && x.FacturaSerie == keyFacturaSerie).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: CntFacturas({keyFacturaId}, {keyFacturaSerie})");
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

        CntFacturas ICntFacturasManager.Delete(int keyFacturaId, int keyFacturaSerie)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntFacturas result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntFacturas.Where((x) => x.FacturaId == keyFacturaId && x.FacturaSerie == keyFacturaSerie).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: CntFacturas({keyFacturaId}, {keyFacturaSerie})");
                    return null;
                }
                else 
                {
                    context.CntFacturas.Remove(result);
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
       
        int ICntFacturasManager.SaveChanges()
        {
            return context.SaveChanges();
        }
	}
}