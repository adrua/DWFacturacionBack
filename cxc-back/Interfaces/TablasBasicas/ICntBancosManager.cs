//ICntBancosManager.cs
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
    public interface ICntBancosManager
	{
        IQueryable<CntBancos> GetAll();
        CntBancos GetById(int keyBancoId);
        CntBancos Add(CntBancos row);
        CntBancos Update(int keyBancoId, Delta<CntBancos> changes);
        CntBancos Delete(int keyBancoId);

        int SaveChanges();
    }
}
