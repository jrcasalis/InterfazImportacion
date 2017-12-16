using ExportarLista.Entities.Configuracion;
using System.Collections.Generic;

namespace ExportarLista.Business.Interfaces
{
    public interface IConfiguracionBusiness
    {
        List<TipoArchivo> BuscarConfiguracionTipoArchivo();
        TipoArchivo BuscarConfiguracionTipoArchivoPorTipo(int tipoArchivo);
    }
}
