using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SettingsDAL
    {
        private string _connection = string.Empty;
        public SettingsDAL(string connection)
        {
            _connection = connection;
        }
        //public DataTable GetConnection()
        //{
        //    return new DatabaseHelper(_connection).DataTable("api_get_connections");
        //}

        //public DataTable GetConnection()
        //{
        //    return new DatabaseHelper(_connection).DataTable("api_get_connections");
        //}
    }
}
