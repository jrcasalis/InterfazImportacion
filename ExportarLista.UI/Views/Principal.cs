using ExportarLista.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportarLista.UI.Views
{
    public partial class Principal : Form
    {
        private string selectedFileToProcess;
        private Microsoft.Practices.Unity.UnityContainer container;
        public Principal()
        {
            container = UnityConfig.RegisterComponents();
            InitializeComponent();
            var appSettings = ConfigurationManager.AppSettings;
            var bussinesName = string.IsNullOrEmpty(appSettings["bussinesName"]) ? "No encontrado" : appSettings["bussinesName"];
            Text = bussinesName;
            MaximizeBox = false;
            btnExport.Visible = false;
            pgrProgress.Visible = false;
            pgrProgress.Value = 0;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog odfSelectFile = new OpenFileDialog();

            var appSettings = ConfigurationManager.AppSettings;
            var initialDirectory = string.IsNullOrEmpty(appSettings["initialDirectory"]) ? "No encontrado" : appSettings["initialDirectory"];

            odfSelectFile.InitialDirectory = initialDirectory;
            odfSelectFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            odfSelectFile.FilterIndex = 2;
            odfSelectFile.RestoreDirectory = true;

            if (odfSelectFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = odfSelectFile.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            txtSelectedFile.Text = odfSelectFile.FileName;
                            btnExport.Visible = true;
                            pgrProgress.Visible = true;
                            selectedFileToProcess = odfSelectFile.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se puede leer el archivo del disco. Error original: " + ex.Message);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            /*ThreadStart threadDelegate = new ThreadStart(this.ExportListFile);
            Thread newThread = new Thread(threadDelegate);
            newThread.Start();*/
            ExportListFile();
        }

        private void ExportListFile()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var initialDirectory = string.IsNullOrEmpty(appSettings["initialDirectory"]) ? "No encontrado" : appSettings["initialDirectory"];

            var outputDirectory = string.IsNullOrEmpty(appSettings["outputDirectory"]) ? "No encontrado" : appSettings["outputDirectory"];

            var dataSeparator = string.IsNullOrEmpty(appSettings["dataSeparator"]) ? "No encontrado" : appSettings["dataSeparator"];
            var IVA = string.IsNullOrEmpty(appSettings["IVA"]) ? "No encontrado" : appSettings["IVA"];
            var profit = string.IsNullOrEmpty(appSettings["profit"]) ? "No encontrado" : appSettings["profit"];

            ExportDataFormat exportDataFormat = new ExportDataFormat()
            {
                DataSeparator = dataSeparator,
                IVA = IVA,
                Profit = profit,
                Form = this
            };

            var exportar = new ExportarArchivo();
            exportar.exportarListaPrecio(container, selectedFileToProcess, outputDirectory, exportDataFormat);
        }

    }
}
