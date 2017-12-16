using ExportarLista.Business.Interfaces;
using ExportarLista.Entities;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportarLista.UI
{
    public class ExportarArchivo
    {
        [Dependency]
        public static IExportarArchivosBusiness ExportarArchivosBusiness { get; set; }

        public void exportarListaPrecio(UnityContainer container, string inputPath, string outputPath, ExportDataFormat exportDataFormat)
        {
            ExportarArchivosBusiness = container.Resolve<IExportarArchivosBusiness>();
            ExportarArchivosBusiness.ExportarListaPrecio(inputPath, outputPath, exportDataFormat);
            
        }
    }
}
