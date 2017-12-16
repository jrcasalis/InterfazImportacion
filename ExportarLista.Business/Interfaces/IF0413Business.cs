using ExportarLista.Entities;
using ExportarLista.Entities.E1;
using System.Collections.Generic;

namespace ExportarLista.Business.Interfaces
{
    public interface IF0413Business
    {
        IEnumerable<F0413> obtenerTodos();
        void eliminar(int id);

        double BuscarIdPorNroPago(double numeroPago);
    }
}
