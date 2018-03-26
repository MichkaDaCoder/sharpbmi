using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Globalization;
using System.Xml;
using SharpBMI.Properties;

namespace SharpBMI.utils
{
    class FormUtils
    {
        /// <summary>
        /// Shows information MessageBox.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        public static void showInfoMessage(string title, string text)
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows an error MessageBox.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        public static void showErrorMessage(string title, string text)
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows a confirmation message.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        public static DialogResult showConfirmationMessage(string title, string text)
        {
            return MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Loads a parameter from app.config file.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string loadConfigs(string config)
        {
            return Settings.Default[config].ToString();
        }

        /// <summary>
        /// Converts a String to a double.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static double convertDouble(string text)
        {
            text.Replace(",",".");
            return Double.Parse(text, NumberStyles.Any);
            throw new FormatException("");
        }

        /// <summary>
        /// Converts a String to int.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int convertInteger(string text)
        {
            return Convert.ToInt32(text);
            throw new FormatException("");
        }

        /// <summary>
        /// Checks if a field is empty.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool EmptyText(string text)
        {
            return String.IsNullOrEmpty(text);
        }

        /// <summary>
        /// Checks if multiple fields are empty.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool ValidChamps(string[] args)
        {
            return string.IsNullOrEmpty(args.ToString());
        }

        /// <summary>
        /// Converts a given date to [dd/MM/yyyy] pattern.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string convertDate(DateTime d)
        {
            return d.ToShortDateString();
        }

        public static void importXML(string fichier, object datasource, string dm, string dataMember)
        {
            XmlDataDocument xdd = new XmlDataDocument();
            xdd.DataSet.ReadXml(fichier);
            datasource = xdd.DataSet;
            dm = dataMember;
        }

        public static void exportToXML(System.Data.DataSet ds, string table, string fichier)
        {
            ds.Tables[table].WriteXml(fichier);
        }

        /// <summary>
        /// Checks if MySQL Service is installed.
        /// </summary>
        /// <returns></returns>
        public static Boolean checkMySQLService()
        {
            ServiceController sc = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == FormUtils.loadConfigs("MYSQL_SERVICE_NAME"));
            return sc == null;
        }

        /// <summary>
        /// Starts MySQL Service.
        /// </summary>
        public static void startMySQLService()
        {
            if (!checkMySQLService())
            {
                ServiceController sc = new ServiceController(FormUtils.loadConfigs("MYSQL_SERVICE_NAME"));

                switch (sc.Status)
                {
                    case ServiceControllerStatus.Stopped:
                        sc.Start();
                        break;

                    case ServiceControllerStatus.Paused:
                        sc.Start();
                        break;
                }
            }
        }

        
    }
}
