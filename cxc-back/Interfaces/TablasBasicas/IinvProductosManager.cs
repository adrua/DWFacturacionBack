//IinvProductosManager.cs
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
    public interface IinvProductosManager
	{
        IQueryable<invProductos> GetAll();
        invProductos GetById(string keyProductoLinea);
        invProductos Add(invProductos row);
        invProductos Update(string keyProductoLinea, Delta<invProductos> changes);
        invProductos Delete(string keyProductoLinea);

        int SaveChanges();
    }
}
