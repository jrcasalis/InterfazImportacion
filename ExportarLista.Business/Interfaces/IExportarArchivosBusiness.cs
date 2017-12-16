using ExportarLista.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportarLista.Business.Interfaces
{
    public interface IExportarArchivosBusiness
    {
        string ExportarListaPrecio(string inputPath, string outputPath, ExportDataFormat exportDataFormat);
    }
}
