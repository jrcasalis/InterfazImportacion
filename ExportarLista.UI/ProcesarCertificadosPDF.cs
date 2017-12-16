using Microsoft.Practices.Unity;
using ExportarLista.Business.Interfaces;
using ExportarLista.Entities.Configuracion;
using System;
using System.IO;

namespace ExportarLista.UI
{
    public class ProcesarCertificadosPDF
    {
        [Dependency]
        public static IPdfBusiness PdfBusiness { get; set; }

       

        /*
         * Método para ejecutar por reflextion. Es necesario que por estandar, este método reciba 
         * un container del tipo UnityContainer para inyectar los servicios
         * y un TipoArchivo para trabajar cada tipo por separado
         * **/
        public void ProcesarPDFs(UnityContainer container,  TipoArchivo tipoCopiar)
        {
            PdfBusiness = container.Resolve<IPdfBusiness>();
            foreach (var documento in tipoCopiar.documentos)
            {
                DirectoryInfo dir = new DirectoryInfo(tipoCopiar.rutaOrigen);
                foreach (var archivo in dir.GetFiles())
                {
                    Console.WriteLine("Archivo: " + archivo.Name);

                    //Solo procesa los archivos que coinciden con el nombre indicado
                    if (archivo.Name.Contains(documento.FormatoNombre))
                    {
                        Console.WriteLine("Este archivo se PROCESA: " + archivo.Name);
                        //Se arma así para dejarlos en una carpeta temporal en espera para ser enviados
                        var directorioEspera = tipoCopiar.rutaDestino + Path.DirectorySeparatorChar + tipoCopiar.directorioEspera;
                        PdfBusiness.DividirPDF(tipoCopiar.rutaOrigen, Path.GetFileNameWithoutExtension(archivo.Name), archivo.Extension, directorioEspera);
                        PdfBusiness.RenombrarPDF(directorioEspera, documento);//documento.FormatoNombre, documento.TipoDocumento, documento.BuscarPor, documento.BuscarHasta, documento.BuscarEn);
                    }
                }
            }
        }
    }
}
