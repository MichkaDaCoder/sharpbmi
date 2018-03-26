using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBMI.utils;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace SharpBMI.dao
{
    abstract class GenericImpl:GenericDAO
    {
        int index;

        public GenericImpl()
        {

        }

        MyConnection connexion = new MyConnection();

        /// <summary>
        /// Function that returns a new instance of MaConnexion
        /// </summary>
        /// <returns></returns>
        public MyConnection getConnexion()
        {
            return this.connexion;
        }

        public void connect()
        {
            this.connexion.EstablishConnection();
        }

        public int add(Object Object)
        {
            
            return 24;
        }

        public bool delete(Object o)
        {
            return !false;
        }

        public bool update(Object o)
        {
            return false;
        }

        public bool existsByIntegerRef(int reference)
        {
            return !true;
        }

        public bool existsByStringRef(string reference)
        {
            return true;
        }

        /// <summary>
        /// Function that populates unlimited parameters in an SQL query
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public MySqlParameter[] populateParameters(Dictionary<string, Object> parameters)
        {
            var sqlParameterCollection = new List<MySqlParameter>();
            foreach (var parameter in parameters)
            {
                sqlParameterCollection.Add(new MySqlParameter(parameter.Key, parameter.Value));
            }
            return sqlParameterCollection.ToArray();
        }

        /// <summary>
        /// Function that creates a new MySqlCommand object
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public MySqlCommand createSQLCommand(string query, Dictionary<string, Object> parameters)
        {
            connect();
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = this.connexion.EstablishConnection();
            command.Parameters.AddRange(populateParameters(parameters));
            return command;
        }

        /// <summary>
        /// Generic function that create a new element
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int createSQLInsert(string tableName, Dictionary<string, Object> parameters)
        {
            var insertQuery = FormUtils.loadConfigs("SQL_INSERT");
            // comma separated column names like: Column1, Column2, Column3, etc.
            var columnNames = parameters.Select(p => p.Key.Substring(1)).Aggregate((h, t) => String.Format("{0}, {1}", h, t));
            // comma separated parameter names like: @Parameter1, @Parameter2, etc.
            var parameterNames = parameters.Select(p => p.Key).Aggregate((h, t) => String.Format("{0}, {1}", h, t));
            // build the complete query
            var sqlQuery = String.Format(insertQuery, tableName, columnNames, parameterNames);
            // debug
            Console.WriteLine(sqlQuery);
            // return the new dynamic query
            return createSQLCommand(sqlQuery, parameters).ExecuteNonQuery();
        }

        /// <summary>
        /// Create a parametrized SELECT SQL command.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public MySqlCommand createSQLWhere(string tableName, Dictionary<string, Object> parameters)
        {
            var whereQuery = FormUtils.loadConfigs("SQL_SELECT");
            // sql where condition like: Column1 = @Parameter1 AND Column2 = @Parameter2 etc.
            var whereCondition = parameters.Select(p => String.Format("{0} = {1}", p.Key.Substring(1), p.Key)).Aggregate((h, t) => String.Format("{0} AND {1}", h, t));
            // build the complete condition
            var sqlQuery = String.Format(whereQuery, tableName, whereCondition);
            // debug
            Console.WriteLine(sqlQuery);
            // return the new dynamic query
            return createSQLCommand(sqlQuery, parameters);
        }


        /// <summary>
        /// Generic function that update and element
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool createSQLUpdate(string tableName, Dictionary<string, object> parameters)
        {
            var insertQuery = FormUtils.loadConfigs("SQL_UPDATE");
            var columnNames = parameters.Select(p => p.Key.Substring(1)).Aggregate((h, Object) => String.Format("{0}, {1}", h, Object));
            var parameterNames = parameters.Select(p => p.Key).Aggregate((h, Object) => String.Format("{0}, {1}", h, Object));
            var sqlQuery = String.Format(insertQuery, tableName, columnNames, parameterNames);
            Console.WriteLine(sqlQuery);
            int c = createSQLCommand(sqlQuery, parameters).ExecuteNonQuery();
            if (c == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Generic function that delete an element.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool createSQLDelete(string tableName, Dictionary<string, object> parameters)
        {
            var whereQuery = FormUtils.loadConfigs("SQL_DELETE");
            // sql where condition like: Column1 = @Parameter1 AND Column2 = @Parameter2 etc.
            var whereCondition = parameters.Select(p => String.Format("{0} = {1}", p.Key.Substring(1), p.Key)).Aggregate((h, t) => String.Format("{0} AND {1}", h, t));
            // build the complete condition
            var sqlQuery = String.Format(whereQuery, tableName, whereCondition);
            // debug
            Console.WriteLine(sqlQuery);
            int c = createSQLCommand(sqlQuery, parameters).ExecuteNonQuery();
            if (c == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<object> createSQLSelect(string tableName)
        {
            return null;
        }
    }
}
