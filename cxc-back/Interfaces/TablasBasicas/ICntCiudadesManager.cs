//ICntCiudadesManager.cs
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
    public interface ICntCiudadesManager
	{
        IQueryable<CntCiudades> GetAll();
        CntCiudades GetById(int keyCiudadDepartamentoId, int keyCiudadid);
        CntCiudades Add(CntCiudades row);
        CntCiudades Update(int keyCiudadDepartamentoId, int keyCiudadid, Delta<CntCiudades> changes);
        CntCiudades Delete(int keyCiudadDepartamentoId, int keyCiudadid);

        int SaveChanges();
    }
}
