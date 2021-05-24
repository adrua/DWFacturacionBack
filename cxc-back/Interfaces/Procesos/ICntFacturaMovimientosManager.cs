//ICntFacturaMovimientosManager.cs
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
    public interface ICntFacturaMovimientosManager
	{
        IQueryable<CntFacturaMovimientos> GetAll();
        CntFacturaMovimientos GetById(int keyFacturaId, int keyFacturaSerie, string keyProductoLinea);
        CntFacturaMovimientos Add(CntFacturaMovimientos row);
        CntFacturaMovimientos Update(int keyFacturaId, int keyFacturaSerie, string keyProductoLinea, Delta<CntFacturaMovimientos> changes);
        CntFacturaMovimientos Delete(int keyFacturaId, int keyFacturaSerie, string keyProductoLinea);

        int SaveChanges();
    }
}
