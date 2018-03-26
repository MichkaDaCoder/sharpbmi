using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpBMI.model;
using SharpBMI.dao;
using SharpBMI.utils;
using SharpBMI.Properties;

namespace SharpBMI.ui
{
    public partial class FormBMI : Form
    {
        BodyMassIndex bmi = new BodyMassIndex();
        BodyMassIndexImplementation bmiImpl = new BodyMassIndexImplementation();

        public FormBMI()
        {
            InitializeComponent();

            saveXML.DefaultExt = FormUtils.loadConfigs("XML_EXTENSION");
            saveXML.Filter = FormUtils.loadConfigs("XML_FILE_FILTER");
            saveXML.FileName = "bmi_" + DateTime.Now.ToString("dd-MM-yyyy") + "";

        }

        private void bodyMassIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: cette ligne de code charge les données dans la table 'db_sharpbmiDataSet.bmi'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
                this.bmiTableAdapter.Fill(this.db_sharpbmiDataSet.bmi);
            }
            catch (ConstraintException ex)
            {
                FormUtils.showErrorMessage("Error", ex.Message + "\n" + ex.StackTrace);
            }

            if (gridHistoryBMI.Rows.Count == 0)
            {
                exportToPDFToolStripMenuItem.Enabled = false;
                exportToXMLToolStripMenuItem.Enabled = false;
            }

            else
            {
                exportToPDFToolStripMenuItem.Enabled = true;
                exportToPDFToolStripMenuItem.Enabled = true;
            }


        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            string[] s = new string[] { txtHeight.Text, txtWeight.Text };

            if (!FormUtils.ValidChamps(s))
            {
                if (FormUtils.EmptyText(txtHeight.Text))
                {
                    errorProvider1.SetError(txtHeight, FormUtils.loadConfigs("EMPTY_HEIGHT"));
                }

                else if (FormUtils.EmptyText(txtWeight.Text))
                {
                    errorProvider1.SetError(txtWeight, FormUtils.loadConfigs("EMPTY_WEIGHT"));
                }

                else
                {
                    try
                    {
                        btn_save.Enabled = true;
                        mapping();
                        this.labResult.Text = "" + bmi.getBMI(bmi.getHeight(), bmi.getWeight());

                        switch (bmi.evaluate())
                        {
                            case "Underweight":
                                changeLabelColor(labResult, Color.Red);
                                break;

                            case "Normal":
                                changeLabelColor(labResult, Color.Green);
                                break;

                            case "Overweight":
                                changeLabelColor(labResult, Color.Red);
                                break;

                            case "Obese":
                                changeLabelColor(labResult, Color.Red);
                                break;

                            case "Severly Obese":
                                changeLabelColor(labResult, Color.Red);
                                break;

                            default:
                                changeLabelColor(labResult, Color.Red);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        FormUtils.showErrorMessage("Error", ex.Message + "\n" + ex.StackTrace);
                    }
                }
            }

            else
            {
                errorProvider1.SetError(txtHeight, "Please fill your height.");
                errorProvider1.SetError(txtWeight, "Please fill your weight.");
            }

        }

        public void mapping()
        {
            string[] s = new string[] { txtWeight.Text, txtHeight.Text };

            if (!FormUtils.ValidChamps(s))
            {
                bmi.setHeight(FormUtils.convertDouble(txtHeight.Text));
                bmi.setWeight(FormUtils.convertDouble(txtWeight.Text));
            }
        }

        public void changeLabelColor(Label label, Color c)
        {
            label.ForeColor = c;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int index = 0;

            if (FormUtils.EmptyText(txtHeight.Text))
            {
                errorProvider1.SetError(txtHeight, FormUtils.loadConfigs("EMPTY_HEIGHT"));
            }

            if (FormUtils.EmptyText(txtWeight.Text))
            {
                errorProvider1.SetError(txtWeight, FormUtils.loadConfigs("EMPTY_WEIGHT"));
            }

            try
            {
                mapToTableAttribute();
                index = bmiImpl.add(bmi);

                if (index == 1)
                {
                    FormUtils.showInfoMessage("Succès", FormUtils.loadConfigs("SUCCESS_ADDED"));
                    Form1_Load(null, null);
                }

                else if (index > 1)
                {
                    FormUtils.showErrorMessage("Echec", FormUtils.loadConfigs("ALREADY_EXISTS"));
                }

                else
                {
                    FormUtils.showErrorMessage("Echec", FormUtils.loadConfigs("FAILURE_ADD"));
                }
                
            }
            catch (Exception ex)
            {
                FormUtils.showErrorMessage("Error", ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void mapToTableAttribute()
        {
            this.bmi = new BodyMassIndex();
            this.bmi.setDateBmi(DateTime.Now.Date);
            this.bmi.setWeight(FormUtils.convertDouble(txtWeight.Text));
            this.bmi.setHeight(FormUtils.convertDouble(txtHeight.Text));
            this.bmi.setResult(FormUtils.convertDouble(labResult.Text));
            this.bmi.setEvaluation(bmi.evaluate());

        }

        private void exportToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormBMIReport().ShowDialog();
        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            new FormBMIReport().ShowDialog();
        }

        /// <summary>
        /// Export datas to an XML file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xml_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = saveXML.ShowDialog();

                switch (dr)
                {
                    case DialogResult.OK:
                       FormUtils.exportToXML(db_sharpbmiDataSet, "bmi", saveXML.FileName);
                        FormUtils.showInfoMessage("Success", FormUtils.loadConfigs("SUCCESS_EXPORTED"));
                        break;

                    case DialogResult.Cancel:
                        return;
                        break;
                }

            }
            catch (Exception ex)
            {
                FormUtils.showErrorMessage("Error", FormUtils.loadConfigs("FAILURE_EXPORTED"));
                FormUtils.showErrorMessage("Error", ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void newCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWeight.Clear();
            txtHeight.Clear();
            labResult.Text = string.Empty;
            btn_save.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = FormUtils.showConfirmationMessage("Confirmation", FormUtils.loadConfigs("CONFIRM_CLOSE_APPLICATION"));

            switch (dr)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;

                case DialogResult.No:
                    return;
                    break;
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                FormUtils.showErrorMessage("Error", ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void whoamiToolStripMenuItem_Click(object sender, EventArgs e)
        {
                  
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exportToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = saveXML.ShowDialog();

                switch (dr)
                {
                    case DialogResult.OK:
                        FormUtils.exportToXML(db_sharpbmiDataSet, "bmi", saveXML.FileName);
                        FormUtils.showInfoMessage("Success", FormUtils.loadConfigs("SUCCESS_EXPORTED"));
                        break;

                    case DialogResult.Cancel:
                        return;
                        break;
                }

            }
            catch (Exception ex)
            {
                FormUtils.showErrorMessage("Error", FormUtils.loadConfigs("FAILURE_EXPORTED"));
                FormUtils.showErrorMessage("Error", ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void FormBMI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = FormUtils.showConfirmationMessage("Confirmation", FormUtils.loadConfigs("CONFIRM_CLOSE_APPLICATION"));

            switch (dr)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;

                case DialogResult.No:
                    return;
                    break;
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
    }
}
