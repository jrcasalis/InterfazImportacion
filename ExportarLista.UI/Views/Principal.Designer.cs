namespace ExportarLista.UI.Views
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSelectedFile = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblSelect = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.pgrProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtSelectedFile
            // 
            this.txtSelectedFile.Location = new System.Drawing.Point(20, 94);
            this.txtSelectedFile.Name = "txtSelectedFile";
            this.txtSelectedFile.Size = new System.Drawing.Size(503, 26);
            this.txtSelectedFile.TabIndex = 1;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(16, 71);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(146, 20);
            this.lblSelect.TabIndex = 3;
            this.lblSelect.Text = "Seleccionar archivo";
            this.lblSelect.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackgroundImage = global::ExportarLista.UI.Properties.Resources.Excel2TXT;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExport.Location = new System.Drawing.Point(132, 141);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(319, 144);
            this.btnExport.TabIndex = 4;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackgroundImage = global::ExportarLista.UI.Properties.Resources.search;
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelect.Location = new System.Drawing.Point(521, 87);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(40, 40);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // pgrProgress
            // 
            this.pgrProgress.ForeColor = System.Drawing.Color.ForestGreen;
            this.pgrProgress.Location = new System.Drawing.Point(20, 295);
            this.pgrProgress.Name = "pgrProgress";
            this.pgrProgress.Size = new System.Drawing.Size(541, 19);
            this.pgrProgress.TabIndex = 5;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 432);
            this.Controls.Add(this.pgrProgress);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.txtSelectedFile);
            this.Controls.Add(this.btnSelect);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtSelectedFile;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ProgressBar pgrProgress;
    }
}