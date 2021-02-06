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
        public DataSet StandardAPI(StandardAPIRequestModel model)
        {
            SqlParameter[] sqlParam = new SqlParameter[]
            {
                    new SqlParameter() {ParameterName = "@Id",Value= CommonHelper.ToDB(model.Id) },
                    new SqlParameter() {ParameterName = "@ProviderId",Value= CommonHelper.ToDB(model.ProviderId) },
                    new SqlParameter() {ParameterName = "@OffSet",Value= CommonHelper.ToDB(model.OffSet) },
                    new SqlParameter() {ParameterName = "@FetchNext",Value= CommonHelper.ToDB(model.FetchNext) },
                    new SqlParameter() {ParameterName = "@DateTimeSince",Value= CommonHelper.ToDB(model.DateTimeSince) },
            };

            return new DatabaseHelper(_connection).GetDatasetData("API_GetStandardProviderList", sqlParam);
        }
    }
}
