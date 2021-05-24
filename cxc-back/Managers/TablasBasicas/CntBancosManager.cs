//CntBancosManager.cs
using System;
using System.Linq;

using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Cxc.TablasBasicas.Interfaces;
using Cxc.TablasBasicas.Models;

namespace Cxc.TablasBasicas.Managers
{
    public class CntBancosManager : ICntBancosManager
	{	
        private readonly ILogger<CntBancosManager> logger;
        private readonly CntContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userId;

        public CntBancosManager(ILogger<CntBancosManager> logger,
                                CntContext context,
                                IHttpContextAccessor httpContextAccessor)
        {
            this.logger = logger;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            //this.userId = ApplicationUserTokenHelper.GetIdFromAuthorization(httpContextAccessor.HttpContext.Request);
        }

        IQueryable<CntBancos> ICntBancosManager.GetAll()
        {
            // Obtenemos el nombre del método para logging
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            IQueryable<CntBancos> result = null;
            
            try
            {
                // Loggeamos el inicio de la operación
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                // obtenemos los datos como IQueryable para optimizar oData
                result = context.CntBancos;
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

        CntBancos ICntBancosManager.GetById(int keyBancoId)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            
            CntBancos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntBancos.Where((x) => x.BancoId == keyBancoId).FirstOrDefault();
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

        CntBancos ICntBancosManager.Add(CntBancos row)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntBancos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntBancos.Where((x) => x.BancoId == row.BancoId).FirstOrDefault();
                
                if (result == null)
                {   
                    result = row;
                    
                    context.Entry(row).Property("Usuario").CurrentValue = userId;
                    context.CntBancos.Add(row);
                }
                else 
                {
                    logger.Log(LogLevel.Error, $"Llave Duplicada: CntBancos({row.BancoId})");
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
        
        CntBancos ICntBancosManager.Update(int keyBancoId, Delta<CntBancos> changes)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntBancos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntBancos.Where((x) => x.BancoId == keyBancoId).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: CntBancos({keyBancoId})");
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

        CntBancos ICntBancosManager.Delete(int keyBancoId)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            CntBancos result = null;

            try
            {
                logger.Log(LogLevel.Debug, $"Iniciando operación: {methodName}");
                result = context.CntBancos.Where((x) => x.BancoId == keyBancoId).FirstOrDefault();

                if (result == null)
                {
                    logger.Log(LogLevel.Error, $"Llave no Existe: CntBancos({keyBancoId})");
                    return null;
                }
                else 
                {
                    context.CntBancos.Remove(result);
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
       
        int ICntBancosManager.SaveChanges()
        {
            return context.SaveChanges();
        }
	}
}