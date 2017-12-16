using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Practices.Unity;
using ExportarLista.Business.Interfaces;
using ExportarLista.Services;
using ExportarLista.Entities.E1;

namespace ExportarLista.Business
{
    public class F0413Business : IF0413Business
    {
        [Dependency]
        public IF0413Repository IF0413Repository { get; set; }

        public IEnumerable<F0413> obtenerTodos()
        {
            try
            {
                var F0413 = IF0413Repository.GetAll().ToList();
                return F0413;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void eliminar(int id)
        {
            IF0413Repository.Delete(id);
        }

        public double BuscarIdPorNroPago(double numeroPago)
        {
            F0413 registro = IF0413Repository.FindBy(x => x.RMDOCM == numeroPago).FirstOrDefault();
            return registro.RMPYID;
        }
    }
}
