using ExportarLista.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var bussinesName = string.IsNullOrEmpty(appSettings["bussinesName"]) ? "Exportador de Excel a txt" : appSettings["bussinesName"];

            Text = bussinesName + "- " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
                        + " - v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            MaximizeBox = false;
            btnExport.Visible = false;
            pgrProgress.Visible = false;
            pgrProgress.Value = 0;
            btnNuevo.Visible = false;
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
                            btnExport.Enabled = true;
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
            btnSelect.Enabled = false;
            btnExport.Enabled = false;
            txtSelectedFile.Enabled = false;
            btnNuevo.Visible = true;
            btnNuevo.Enabled = false;
            ExportListFile();

            /*ThreadStart threadDelegate = new ThreadStart(this.ExportListFile);
            Thread newThread = new Thread(threadDelegate);
            newThread.Start();*/
        }

        private void ExportListFile()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var initialDirectory = string.IsNullOrEmpty(appSettings["initialDirectory"]) ? @"C:\" : appSettings["initialDirectory"];

            var outputDirectory = string.IsNullOrEmpty(appSettings["outputDirectory"]) ? @"C:\" : appSettings["outputDirectory"];

            var dataSeparator = string.IsNullOrEmpty(appSettings["dataSeparator"]) ? "No encontrado" : appSettings["dataSeparator"];
            var IVA = string.IsNullOrEmpty(appSettings["IVA"]) ? "0" : appSettings["IVA"];
            var profit = string.IsNullOrEmpty(appSettings["profit"]) ? "0" : appSettings["profit"];
            var useProfit = Boolean.Parse(string.IsNullOrEmpty(appSettings["useProfit"]) ? "false" : appSettings["useProfit"]);
            var useIVA = Boolean.Parse(string.IsNullOrEmpty(appSettings["useIVA"]) ? "false" : appSettings["useIVA"]);
            var firstLineEmpty = Boolean.Parse(string.IsNullOrEmpty(appSettings["firstLineEmpty"]) ? "false" : appSettings["firstLineEmpty"]);

            ExportDataFormat exportDataFormat = new ExportDataFormat()
            {
                DataSeparator = dataSeparator,
                IVA = IVA,
                Profit = profit,
                UseIVA = useIVA,
                UseProfit = useProfit,
                Form = this,
                FirstLineEmpty = firstLineEmpty
            };

            var exportar = new ExportarArchivo();
            exportar.exportarListaPrecio(container, selectedFileToProcess, outputDirectory, exportDataFormat);
            btnNuevo.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnSelect.Enabled = true;
            btnExport.Visible = false;
            txtSelectedFile.Enabled = true;
            txtSelectedFile.Text = "";
            selectedFileToProcess = "";
            btnNuevo.Visible = false;
            pgrProgress.Visible = false;
            pgrProgress.Value = 0;
        }
    }
}
