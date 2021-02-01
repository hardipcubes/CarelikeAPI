using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public class SettingsBLL
    {
        private SettingsDAL DAL;
        private string _connection = string.Empty;
        public SettingsBLL(string connection)
        {
            _connection = connection;
            DAL = new SettingsDAL(connection);
        }

        public ConnectionModel GetConnection()
        {
            ConnectionModel mdl = new ConnectionModel();
            mdl.HLDCore = _connection;
            return mdl;
        }

    }
}
