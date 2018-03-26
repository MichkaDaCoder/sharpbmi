using MySql.Data.MySqlClient;
using SharpBMI.dao;
using SharpBMI.ui;
using SharpBMI.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpBMI
{
    static class Program
    {
        static MyConnection con = new MyConnection();
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool installed = FormUtils.checkMySQLService();

            if (installed)
            {
                FormUtils.showErrorMessage("Erreur", FormUtils.loadConfigs("UNINSTALLED_MYSQL_SERVICE"));
            }

            else
            {
                try
                {
                    FormUtils.startMySQLService();
                    FormUtils.showInfoMessage("Info", FormUtils.loadConfigs("SUCCESS_MYSQL_START"));
                }
                catch (Exception ex)
                {
                    FormUtils.showErrorMessage("Error", FormUtils.loadConfigs("FAILURE_MYSQL_START"));
                    FormUtils.showErrorMessage("Error", ex.Message);
                    Application.Exit();
                }

                try
                {
                    if (con.EstablishConnection().State.Equals(ConnectionState.Open))
                    {
                        FormUtils.showInfoMessage("Information", FormUtils.loadConfigs("SUCCESS_DATABASE_CONNECTION"));
                        Application.Run(new FormBMI());
                    }

                    else if (con.EstablishConnection().State.Equals(ConnectionState.Closed))
                    {
                        FormUtils.showErrorMessage("Error", FormUtils.loadConfigs("ERROR_DATABASE_CONNECTION"));
                        Application.Exit();
                    }
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            FormUtils.showErrorMessage("Error", "Cannot connect to server.  Contact administrator");
                            break;

                        case 1045:
                            FormUtils.showErrorMessage("Error", "Invalid username/password, please try again");
                            break;
                    }
                }
            }
        }
    }
}
