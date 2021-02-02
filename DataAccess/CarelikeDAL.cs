using BusinessObjects;
using DataAccess.Helper;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CarelikeDAL
    {
        private string _connection = string.Empty;
        public CarelikeDAL(string connection)
        {
            _connection = connection;
        }
        public DataTable StandardAPI(StandardAPIRequestModel model)
        {
            SqlParameter[] sqlParam = new SqlParameter[]
            {
                    new SqlParameter() {ParameterName = "@Id",Value= CommonHelper.ToDB(model.Id) },
                    new SqlParameter() {ParameterName = "@ProviderId",Value= CommonHelper.ToDB(model.ProviderId) },
                    new SqlParameter() {ParameterName = "@DisplayRecordFrom",Value= CommonHelper.ToDB(model.DisplayRecordFrom) },
                    new SqlParameter() {ParameterName = "@DisplayRecordTo",Value= CommonHelper.ToDB(model.DisplayRecordTo) },
                    new SqlParameter() {ParameterName = "@DateTimeSince",Value= CommonHelper.ToDB(model.DateTimeSince) },
            };

            return new DatabaseHelper(_connection).DataTable("API_GetStandardProviderList", sqlParam);
        }
    }
}
