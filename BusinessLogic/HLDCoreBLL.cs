using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLogic
{
    public class HLDCoreBLL : BaseBLL
    {
        private HLDCoreDAL DAL;
        public HLDCoreBLL(string connection)
        {
            DAL = new HLDCoreDAL(connection);
        }

        public List<ApplicationResultModel> GetApplicationList(ApplicationParamModel model)
        {
            List<ApplicationResultModel> lstmodel = new List<ApplicationResultModel>();
            DataTable dt = DAL.GetApplicationList(model);

            #region Fill Model Value
            if (dt != null && dt.Rows.Count > 0)
            {
                List<string> bindOnLoad = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    #region CaseFilter
                    ApplicationResultModel mdl = new ApplicationResultModel();
                    mdl.ApplicationId = SafeValue<int>(row["ApplicationId"]);

                    mdl.ApplicationName = SafeValue<string>(row["ApplicationName"]);
                    mdl.ApplicationDesc = SafeValue<string>(row["ApplicationDesc"]);
                    mdl.ApplicationLogo = SafeValue<string>(row["ApplicationLogo"]);
                    mdl.ApplicationCode = SafeValue<string>(row["ApplicationCode"]);
                    mdl.DisplayOrder = SafeValue<int>(row["DisplayOrder"]);
                    mdl.IsActive = SafeValue<bool>(row["IsActive"]);
                    mdl.CreatedBy = SafeValue<int>(row["CreatedBy"]);
                    mdl.CreatedOn = SafeValue<DateTime>(row["CreatedOn"]);
                    mdl.ModifiedBy = SafeValue<int>(row["ModifiedBy"]);
                    mdl.ModifiedOn = SafeValue<DateTime>(row["ModifiedOn"]);
                    mdl.ApplicationDomain = SafeValue<string>(row["ApplicationDomain"]);
                    lstmodel.Add(mdl);
                    #endregion
                }

            }

            #endregion

            return lstmodel;
        }

    }
}
