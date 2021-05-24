//ICntFacturasManager.cs
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;

using Cxc.Procesos.Models;

namespace Cxc.Procesos.Interfaces
{
    public interface ICntFacturasManager
	{
        IQueryable<CntFacturas> GetAll();
        CntFacturas GetById(int keyFacturaId, int keyFacturaSerie);
        CntFacturas Add(CntFacturas row);
        CntFacturas Update(int keyFacturaId, int keyFacturaSerie, Delta<CntFacturas> changes);
        CntFacturas Delete(int keyFacturaId, int keyFacturaSerie);

        int SaveChanges();
    }
}
