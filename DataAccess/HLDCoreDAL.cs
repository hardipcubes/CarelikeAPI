using BusinessObjects;
using DataAccess.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HLDCoreDAL
    {
        private string _connection = string.Empty;
        public HLDCoreDAL(string connection)
        {
            _connection = connection;
        }
        public DataTable GetApplicationList(ApplicationParamModel model)
        {
            SqlParameter[] sqlParam = new SqlParameter[]
            {
                    new SqlParameter() {ParameterName = "@UserName",Value= CommonHelper.ToDB(model.UserName) }
            };

            return new DatabaseHelper(_connection).DataTable("api_get_application_list", sqlParam);
        }
    }
}
