using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SharpBMI.utils;
using MySql.Data.MySqlClient;

namespace SharpBMI.dao
{
    class MyConnection : IConnexion
    {
        #region Declaration of attributes.
       MySqlConnection con;
       MySqlTransaction mt;

        string SQL_SERVER;
        string SQL_DATABASE;
        string SQL_UID;
        string SQL_PASSWORD;
        string SQL_CONNECTION_STRING;

        #endregion

        public MyConnection()
        {

        }

        /// <summary>
        /// Establish a new connection to Sql Database.
        /// </summary>
        /// <returns></returns>
        public MySqlConnection EstablishConnection()
        {
            SQL_SERVER = FormUtils.loadConfigs("server");
            SQL_DATABASE = FormUtils.loadConfigs("database");
            SQL_UID = FormUtils.loadConfigs("uid");
            SQL_PASSWORD = FormUtils.loadConfigs("password");
            SQL_CONNECTION_STRING = "server=" + SQL_SERVER + ";database=" + SQL_DATABASE + ";uid=" + SQL_UID + ";password=" + SQL_PASSWORD + "";
            con = new MySqlConnection(SQL_CONNECTION_STRING);
            con.Open();
            return con;
        }

        /// <summary>
        /// Close the database connection.
        /// </summary>
        public void CloseConnection()
        {
            if (con != null)
            {
                con.Close();
            }
        }

        /// <summary>
        /// Gets the current state of the database connection.
        /// </summary>
        /// <returns></returns>
        public ConnectionState getEtatConnexion()
        {
            return con.State;
        }


        public MySqlTransaction getCurrentTransaction()
        {
            this.mt = con.BeginTransaction();
            return this.mt;
        }

        /// <summary>
        /// Abort current SQL transactions.
        /// </summary>
        /// <returns></returns>
        public MySqlTransaction AbortTransactions()
        {
            mt.Rollback();
            return this.mt;
        }

        /// <summary>
        /// Getter of SqlCommand.
        /// </summary>
        /// <returns></returns>
        public MySqlCommand getSqlCommand()
        {
            MySqlCommand cmd = new MySqlCommand();
            return cmd;
        }
    }
}
