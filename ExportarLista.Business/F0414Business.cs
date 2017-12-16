using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Practices.Unity;
using ExportarLista.Business.Interfaces;
using ExportarLista.Services;

namespace ExportarLista.Business
{
    public class F0414Business //: IF0414Business
    {
        //[Dependency]
        //public IF0414Repository IF0414Repository { get; set; }

        //public IEnumerable<F0414> obtenerTodos()
        //{
        //    try
        //    {
        //        var F0414 = IF0414Repository.GetAll().ToList();
        //        return F0414;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
            
        //}

        //public void eliminar(int id)
        //{
        //    IF0414Repository.Delete(id);
        //}

        //public double BuscarIdPorTipoYNumeroDocumento(string rndct, double numeroDocumento)
        //{
        //    var id = IF0414Repository.FindBy(x => x.RNDCT == rndct && x.RNDOC == numeroDocumento).FirstOrDefault();
        //    return id.RNPYID;
        //}
    }
}
