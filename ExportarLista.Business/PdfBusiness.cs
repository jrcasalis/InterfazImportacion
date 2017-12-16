using ExportarLista.Business.Interfaces;
using ExportarLista.Entities.Exceptions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.IO;
using System.Text;
using iTextSharp.text;
using System.Collections.Generic;
using ExportarLista.Entities.PDF;
using Microsoft.Practices.Unity;
using ExportarLista.Services;
using ExportarLista.Entities;

namespace ExportarLista.Business
{
    public class PdfBusiness : IPdfBusiness
    {
        [Dependency]
        public IF0413Repository F0413Repository { get; set; }
        [Dependency]
        public IF0413Business F0413Business { get; set; }
        [Dependency]
        public IF0414Business F0414Business { get; set; }

        public String BuscarDatosPdf(string nombreArchivo)
        {
            /*path = path + “/ extjs.pdf”;
            string salida = ReadPdfFile(path);

            y luego defino el método*/
            try
            {
                PdfReader reader2 = new PdfReader(nombreArchivo);
                string strText = string.Empty;

                for (int page = 1; page <= reader2.NumberOfPages; page++)
                {
                    ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                    PdfReader reader = new PdfReader(nombreArchivo);
                    String s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                    s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                    strText = strText + s;
                    reader.Close();
                }
                reader2.Close();
                return strText;
            }
            catch (IOException ex)
            {
                throw new ExportException("Error: No se encuentra el archivo o recurso: " + nombreArchivo + ". --> Traza Original: " + ex.StackTrace);
            }

        }

        public void DividirPDF(String rutaOrigenPDF, String nombrePDFEntrada, String extension, String rutaSalidaPDF)
        {
            DividirPDF(rutaOrigenPDF, nombrePDFEntrada, "", extension, rutaSalidaPDF);
        }

        public void DividirPDF(String rutaOrigenPDF, String nombrePDFEntrada, String nombrePDFSalida, String extension, String rutaSalidaPDF)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;
            try
            {
                if (nombrePDFSalida.Equals(""))
                {
                    nombrePDFSalida = nombrePDFEntrada;
                }

                //Limpia el último punto del nombre en caso que exista
                nombrePDFEntrada = nombrePDFEntrada.Replace(".", "");

                //Inicializa una instancia de PdfReader con el contenido del pdf origen:
                var inputPDFFile = rutaOrigenPDF + System.IO.Path.DirectorySeparatorChar + nombrePDFEntrada + extension;
                reader = new PdfReader(inputPDFFile);

                int startPage = 1;
                int endPage = reader.NumberOfPages;

                //Verifica que el directorio de destino funcione, además se lo redirecciona
                //a un directorio nuevo de documentos divididos
                DirectoryInfo outputDir = new DirectoryInfo(rutaSalidaPDF);
                if (!outputDir.Exists)
                {
                    outputDir.Create();
                }

                //Recorre las páginas y agrega una por una al archivo de salida
                for (int i = startPage; i <= endPage; i++)
                {
                    //Se asume que las páginas son del mismo tamaño y orientación que la primera
                    sourceDocument = new Document(reader.GetPageSizeWithRotation(startPage));

                    //Inicializa una instancia de PdfCopyClass con el documento origen y un output file stream
                    String outuExportarListaFile = rutaSalidaPDF + System.IO.Path.DirectorySeparatorChar + nombrePDFSalida +
                        "_P_" + i.ToString().PadLeft(5,'0') + extension;
                    pdfCopyProvider = new PdfCopy(sourceDocument,
                        new System.IO.FileStream(outuExportarListaFile, System.IO.FileMode.Create));

                    sourceDocument.Open();

                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                    sourceDocument.Close();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new ExportException(ex.Message);
            }
        }

        public void RenombrarPDF(String directorioOrigen, Documento documento)
        {
            try
            {
                List<ArchivoUnir> archivosUnir = new List<ArchivoUnir>();
                DirectoryInfo dDirectorio = new DirectoryInfo(directorioOrigen);
                string[] ultimoDocumentoProcesado = new string[] {"","",""};
                foreach (var archivo in dDirectorio.GetFiles())
                {
                    var contadorTemporal = 0;
                    if (archivo.Name.Contains(documento.FormatoNombre))
                    {
                        //Lee el nro de documento
                        var contenido = BuscarDatosPdf(archivo.FullName);
                        if (contenido.Contains("\n"))
                        {
                            contenido = contenido.Replace("\n", "\\n");
                        }
                        var primerCorteArray = contenido.Split(new string[] { documento.BuscarPor }, StringSplitOptions.None);
                        if (primerCorteArray.Length > 1)
                        {
                            var primerCorte = primerCorteArray[1].Trim();
                            var nroDocumento = primerCorte.Split(new string[] { documento.BuscarHasta }, StringSplitOptions.None)[0].Trim();
                            if (!Convert.ToDouble(nroDocumento).Equals(0))
                            {
                                var idPago = 0D;
                                switch (documento.BuscarEn)
                                {
                                    case "F0413":
                                        idPago = contadorTemporal + 1; //F0413Business.BuscarIdPorNroPago(Convert.ToDouble(nroDocumento));
                                        break;
                                    case "F0414":
                                        idPago = contadorTemporal + 1; //F0414Business.BuscarIdPorTipoYNumeroDocumento(documento.Identificacion, Convert.ToDouble(nroDocumento));
                                        break;
                                    default:
                                        throw new ExportException("El dato de tabla a buscar: " + documento.BuscarEn + " es incorrecto");
                                }

                                var archivoReemplazo = directorioOrigen + System.IO.Path.DirectorySeparatorChar +
                                    nroDocumento + "_" + documento.TipoDocumento + archivo.Extension;

                                //Verifica si ya existe un archivo con el mismo nombre, caso positivo, le agrega una página al archivo este
                                FileInfo archivoNuevo = new FileInfo(archivoReemplazo);
                                if (archivoNuevo.Exists)
                                {
                                    //Lo guarda en una lista de ArchivosUnir para procesarlos al finalizar
                                    ArchivoUnir archivoUnir = new ArchivoUnir
                                    {
                                        archivoOriginal = archivoNuevo.FullName,
                                        archivoAgregar = archivo.FullName,
                                        archivoTemporalCopia = directorioOrigen + System.IO.Path.DirectorySeparatorChar +
                                            System.IO.Path.GetFileNameWithoutExtension(archivoNuevo.Name) +
                                            "temp" + archivoNuevo.Extension
                                    };
                                    archivosUnir.Add(archivoUnir);
                                }
                                else
                                {
                                    archivo.MoveTo(archivoReemplazo);
                                }
                                //Guarda el último documento por si encuentra alguna hoja en blanco o sin referencia a documentos,
                                //se la agrega al último que procesó bien
                                ultimoDocumentoProcesado = ultimoDocumentoProcesado = new string[] {archivoNuevo.FullName, archivoNuevo.Name, archivoNuevo.Extension };
                            }
                            else
                            {
                                archivo.Delete();
                            }
                        }
                        else
                        {
                            //No encuentra datos, concatena la hoja al documento anterior
                            //Lo guarda en una lista de ArchivosUnir para procesarlos al finalizar
                            ArchivoUnir archivoUnir = new ArchivoUnir
                            {
                                archivoOriginal = ultimoDocumentoProcesado[0],
                                archivoAgregar = archivo.FullName,
                                archivoTemporalCopia = directorioOrigen + System.IO.Path.DirectorySeparatorChar +
                                    System.IO.Path.GetFileNameWithoutExtension(ultimoDocumentoProcesado[1]) +
                                    "temp" + ultimoDocumentoProcesado[2]
                            };
                            archivosUnir.Add(archivoUnir);
                        }
                        
                    }
                }
                if (archivosUnir.Count > 0)
                {
                    CombinarPDF(archivosUnir);
                }
               
            }
            catch (IOException ioEx)
            {
                throw new ExportException(ioEx.Message);
            }
        }

        /**********************************************************************
         * A partir de una lista de tipo <ArchivoUnir> rearma los pdfs con el
         * mismo número de documento en uno solo.
         * ********************************************************************/
        public static void CombinarPDF(List<ArchivoUnir> archivosUnir)
        {
            foreach (var archivo in archivosUnir)
            {
                string[] fileNames = new string[] { archivo.archivoOriginal, archivo.archivoAgregar };

                using (FileStream stream = new FileStream(archivo.archivoTemporalCopia, FileMode.Create))
                {
                    Document document = new Document();
                    PdfCopy pdf = new PdfCopy(document, stream);
                    PdfReader reader = null;
                    try
                    {
                        document.Open();
                        foreach (string file in fileNames)
                        {
                            reader = new PdfReader(file);
                            pdf.AddDocument(reader);
                            reader.Close();
                        }
                        if (document != null)
                        {
                            document.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                        if (document != null)
                        {
                            document.Close();
                        }
                        throw new ExportException(e.Message);
                    }
                }
                //Borra el archivo ya nombrado así lo puede reemplazar con el nuevo
                FileInfo archivoFinal = new FileInfo(archivo.archivoOriginal);
                archivoFinal.Delete();
                //Renombra el nuevo archivo temporal unido a uno definitivo
                archivoFinal = new FileInfo(archivo.archivoTemporalCopia);
                archivoFinal.MoveTo(archivo.archivoOriginal);
                //Borra el otro archivo que ya se unió al anterior
                archivoFinal = new FileInfo(archivo.archivoAgregar);
                archivoFinal.Delete();
            }
        }
    }
}
