//ICntCodigosCiiuManager.cs
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
    public interface ICntCodigosCiiuManager
	{
        IQueryable<CntCodigosCiiu> GetAll();
        CntCodigosCiiu GetById(string keyCodigoCiiuId);
        CntCodigosCiiu Add(CntCodigosCiiu row);
        CntCodigosCiiu Update(string keyCodigoCiiuId, Delta<CntCodigosCiiu> changes);
        CntCodigosCiiu Delete(string keyCodigoCiiuId);

        int SaveChanges();
    }
}
