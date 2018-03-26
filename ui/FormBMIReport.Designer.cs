namespace SharpBMI.ui
{
    partial class FormBMIReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportBMI = new Microsoft.Reporting.WinForms.ReportViewer();
            this.db_sharpbmiDataSet = new SharpBMI.db_sharpbmiDataSet();
            this.bmiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bmiTableAdapter = new SharpBMI.db_sharpbmiDataSetTableAdapters.bmiTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.db_sharpbmiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportBMI
            // 
            this.reportBMI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportBMI.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bmiBindingSource;
            this.reportBMI.LocalReport.DataSources.Add(reportDataSource1);
            this.reportBMI.LocalReport.ReportEmbeddedResource = "SharpBMI.report.ReportBMI.rdlc";
            this.reportBMI.Location = new System.Drawing.Point(0, 0);
            this.reportBMI.Name = "reportBMI";
            this.reportBMI.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportBMI.Size = new System.Drawing.Size(612, 324);
            this.reportBMI.TabIndex = 0;
            // 
            // db_sharpbmiDataSet
            // 
            this.db_sharpbmiDataSet.DataSetName = "db_sharpbmiDataSet";
            this.db_sharpbmiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bmiBindingSource
            // 
            this.bmiBindingSource.DataMember = "bmi";
            this.bmiBindingSource.DataSource = this.db_sharpbmiDataSet;
            // 
            // bmiTableAdapter
            // 
            this.bmiTableAdapter.ClearBeforeFill = true;
            // 
            // FormBMIReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 324);
            this.Controls.Add(this.reportBMI);
            this.Name = "FormBMIReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpBMI";
            this.Load += new System.EventHandler(this.FormBMIHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.db_sharpbmiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmiBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportBMI;
        private db_sharpbmiDataSet db_sharpbmiDataSet;
        private System.Windows.Forms.BindingSource bmiBindingSource;
        private db_sharpbmiDataSetTableAdapters.bmiTableAdapter bmiTableAdapter;

    }
}