//IinvSaldosManager.cs
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;

using Cxc.TablasBasicas.Models;

namespace Cxc.TablasBasicas.Interfaces
{
    public interface IinvSaldosManager
	{
        IQueryable<invSaldos> GetAll();
        invSaldos GetById(string keyProductoLinea, string keyPeriodoDescripcionx);
        invSaldos Add(invSaldos row);
        invSaldos Update(string keyProductoLinea, string keyPeriodoDescripcionx, Delta<invSaldos> changes);
        invSaldos Delete(string keyProductoLinea, string keyPeriodoDescripcionx);

        int SaveChanges();
    }
}
