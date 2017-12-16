using ExportarLista.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportarLista.Business.Interfaces
{
    public interface IExportarListas
    {
        String BuscarDatosPdf(String NombreArchivo);
        void DividirPDF(String rutaOrigenPDF, String nombrePDFEntrada, String extension, String rutaSalidaPDF);
        void DividirPDF(String rutaOrigenPDF, String nombrePDFEntrada, String nombrePDFSalida, String extension, String rutaSalidaPDF);
        void RenombrarPDF(String directorioOrigen, Documento documento);//String nombreContiene, String tipoDocumento, String substringDesde, String substringHasta, String tablaBuscar);
    }
}
