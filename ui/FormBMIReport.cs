using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpBMI.ui
{
    public partial class FormBMIReport : Form
    {

        public FormBMIReport()
        {
            InitializeComponent();

            this.reportBMI.LocalReport.DisplayName = "bmi_" + DateTime.Now.ToString("dd-MM-yyyy") + "";
        }

        private void FormBMIHistory_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'db_sharpbmiDataSet.bmi'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.bmiTableAdapter.Fill(this.db_sharpbmiDataSet.bmi);
            // TODO: cette ligne de code charge les données dans la table 'database1DataSet.BMI'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            


            this.reportBMI.RefreshReport();
        }
        
    }

}
