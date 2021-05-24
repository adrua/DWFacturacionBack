//ICntClientesManager.cs
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
    public interface ICntClientesManager
	{
        IQueryable<CntClientes> GetAll();
        CntClientes GetById(decimal keyClienteId);
        CntClientes Add(CntClientes row);
        CntClientes Update(decimal keyClienteId, Delta<CntClientes> changes);
        CntClientes Delete(decimal keyClienteId);

        int SaveChanges();
    }
}
