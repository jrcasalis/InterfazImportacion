using ExportarLista.Business.Interfaces;
using ExportarLista.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportarLista.Business
{
    public class ExportarArchivosBusiness : IExportarArchivosBusiness
    {
        //[Dependency]
        //public IF0413Repository F0413Repository { get; set; }
        //[Dependency]
        //public IF0413Business F0413Business { get; set; }
        //[Dependency]
        //public IF0414Business F0414Business { get; set; }
        List<Control> ControlList = new List<Control>();
        public string ExportarListaPrecio(string inputPath, string outputPath, ExportDataFormat exportDataFormat)
        {
            ControlList = new List<Control>();
            Console.WriteLine("Llega");
            //Lee el excel
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\jrcasalis\Desktop\Datos.xlsx");
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(inputPath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            //Busca la última fila
            int rowCount = xlWorksheet.get_Range("A" + xlWorksheet.Rows.Count).get_End(Excel.XlDirection.xlUp).Row;
            var colCount = 8;

            //Obtiene la barra de progreso
            GetAllControls(exportDataFormat.Form);
            foreach(ProgressBar progress in ControlList)
            {
                progress.Maximum = rowCount + 1;
                progress.Minimum = 0;
                progress.Step = 1;
            }

            List<String> lines = new List<string>();

            for (int i = 2; i <= rowCount; i++) //<= 20; i++)//
            {
                //Formato de salida: Codigo de proveedor, descripción, IVA 21% y % de ganancia, y costo unitario
                if (!object.ReferenceEquals(xlRange.Cells[i, 1].Value2, null))
                {
                    Console.WriteLine("Articulo: " + xlRange.Cells[i, 1].Value2.ToString().Trim());
                    StringBuilder line = new StringBuilder();
                    String code = xlRange.Cells[i, 1].Value2.ToString().Trim();
                    line.Append(code);
                    line.Append(exportDataFormat.DataSeparator);
                    String description = xlRange.Cells[i, 2].Value2.ToString().Trim();
                    description = description.Replace(',', '.');
                    line.Append(description);
                    line.Append(exportDataFormat.DataSeparator);
                    //Sólo guarda el IVA si está seteado para que lo haga
                    if (exportDataFormat.UseIVA)
                    {
                        line.Append(exportDataFormat.IVA);
                        line.Append(exportDataFormat.DataSeparator);
                    }
                    //Sólo guarda la ganancia si está seteado para que lo haga
                    if (exportDataFormat.UseProfit)
                    {
                        line.Append(exportDataFormat.Profit);
                        line.Append(exportDataFormat.DataSeparator);
                    }
                    String price = xlRange.Cells[i, 4].Value2.ToString().Trim();
                    price = price.Replace(".", "").Replace(",", ".");
                    line.Append(price);
                    //line.Append(Environment.NewLine);
                    lines.Add(line.ToString());
                    //Aumenta la barra de progreso
                    foreach (ProgressBar progress in ControlList)
                    {
                        progress.PerformStep();
                    }
                    Console.WriteLine("Línea " + i.ToString());
                }
                else
                {
                    closeExcel(xlApp, xlWorkbook, xlWorksheet, xlRange);
                    throw new Entities.Exceptions.ExportException("El archivo Excel no contiene datos o no son válidos");
                }
            }

            try
            {

                /*System.IO.StreamWriter file = new System.IO.StreamWriter(outputPath + @"\ListaPrecio.txt");
                file.WriteLine(line.ToString()); // "sb" is the StringBuilder*/
                var dateFile = DateTime.Today;
                var outputFileName = "ListaPrecio_" + dateFile.Year.ToString().PadLeft(2, '0') + dateFile.Month.ToString().PadLeft(2, '0') + dateFile.Day.ToString().PadLeft(2, '0')+ ".txt";
                outputFileName = outputPath + Path.DirectorySeparatorChar + outputFileName;
                TextWriter tw = new StreamWriter(outputFileName);
                foreach (string s in lines)
                    tw.WriteLine(s);

                tw.Close();
                //Aumenta la barra de progreso
                foreach (ProgressBar progress in ControlList)
                {
                    progress.PerformStep();
                }
            }
            catch (Exception e)
            {

                throw new Entities.Exceptions.ExportException("Error al grabar el archivo de salida. Mensaje original: " + e.Message);
            }
            finally
            {
                closeExcel(xlApp, xlWorkbook, xlWorksheet, xlRange);
            }
            return "";
        }

        private static void closeExcel(Excel.Application xlApp, Excel.Workbook xlWorkbook, Excel._Worksheet xlWorksheet, Excel.Range xlRange)
        {
            xlWorkbook.Close();
            //quit and release
            xlApp.Quit();

            //release com objects to fully kill excel process from running in the background
            releaseObject(xlRange);
            releaseObject(xlWorksheet);
            releaseObject(xlWorkbook);
            releaseObject(xlApp);
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Terminó");
        }

        private static void releaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                GetAllControls(c);
                if (c is ProgressBar) ControlList.Add(c);
            }
        }
    }



}
