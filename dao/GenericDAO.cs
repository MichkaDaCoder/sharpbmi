using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace SharpBMI.dao
{
    interface GenericDAO
    {
        bool existsByIntegerRef(int reference);
        bool existsByStringRef(string reference);
        MySqlParameter[] populateParameters(Dictionary<String, Object> parameters);
        MySqlCommand createSQLCommand(string query, Dictionary<String, Object> parameters);
        int createSQLInsert(String tableName, Dictionary<String, object> parameters);
        bool createSQLUpdate(String tableName, Dictionary<String, object> parameters);
        bool createSQLDelete(String tableName, Dictionary<String, object> parameters);
        List<Object> createSQLSelect(String tableName);
        MySqlCommand createSQLWhere(String tableName, Dictionary<String, Object> parameters);
    }
}
