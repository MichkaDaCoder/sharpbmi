using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace SharpBMI.dao
{
    interface IConnexion
    {
        /// <summary>
        /// Establish a new connection to MySQL database.
        /// </summary>
        /// <returns></returns>
         MySqlConnection EstablishConnection();

        /// <summary>
        /// Close opened MySQL Database connection
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// Gets actual state of the Database connection.
        /// </summary>
        /// <returns></returns>
        ConnectionState getEtatConnexion();

        /// <summary>
        /// Gets the current transaction
        /// </summary>
        /// <returns></returns>
        MySqlTransaction getCurrentTransaction();

        /// <summary>
        /// Aborts current transactions.
        /// </summary>
        /// <returns></returns>
        MySqlTransaction AbortTransactions();

        /// <summary>
        /// Get MySqlCommand object
        /// </summary>
        /// <returns>MySqlCommand</returns>
        MySqlCommand getSqlCommand();

    }
}
