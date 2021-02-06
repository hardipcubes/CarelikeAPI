using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BusinessLogic
{
    public class CarelikeBLL : BaseBLL
    {
        private CarelikeDAL DAL;
        public CarelikeBLL(string connection)
        {
            DAL = new CarelikeDAL(connection);
        }

        public List<APIProvider> StandardAPI(StandardAPIRequestModel model)
        {
            List<APIProvider> lstmodel = new List<APIProvider>();
            DataSet ds = DAL.StandardAPI(model);

            if (ds == null)
                return lstmodel;


            #region Bind CustomerAPI table field
            TblCustomerAPI objCustomerAPI = new TblCustomerAPI();
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow tblCustomerAPI in ds.Tables[0].Rows)
                {
                    #region fill CustomerAPI table property
                    objCustomerAPI.APIId = SafeValue<int>(tblCustomerAPI["APIId"]);
                    objCustomerAPI.WelcomeTitle = SafeValue<string>(tblCustomerAPI["WelcomeTitle"]);
                    objCustomerAPI.Instruction = SafeValue<string>(tblCustomerAPI["Instruction"]);
                    objCustomerAPI.PrivacyPolicyValue = SafeValue<string>(tblCustomerAPI["PrivacyPolicyValue"]);
                    objCustomerAPI.TermsOfServiceValue = SafeValue<string>(tblCustomerAPI["TermsOfServiceValue"]);
                    objCustomerAPI.FromDate = SafeValue<DateTime>(tblCustomerAPI["FromDate"]);
                    objCustomerAPI.ToDate = SafeValue<DateTime>(tblCustomerAPI["ToDate"]);
                    #endregion
                }

            }

            #endregion

            #region Bind provider table field
            if (ds != null && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            {

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    #region Fill Result Set
                    APIProvider obj = new APIProvider();
                    obj.ProviderId = SafeValue<string>(row["ProviderId"]);
                    obj.PartyId = SafeValue<int>(row["Partyid"]);
                    obj.CreatedDate = SafeValue<DateTime>(row["CreatedDate"]);
                    obj.ModifiedDate = SetModifiedDate(SafeValue<DateTime>(row["ModifiedDate"]));
                    obj.UntilDate = SetModifiedDate(SafeValue<DateTime>(row["UntilDate"]));
                    obj.FKAName = SafeValue<string>(row["FKAName"]);
                    obj.LAName = SafeValue<string>(row["LAName"]);

                    var _Addresses = GetProviderAddresses(ds, obj.ProviderId);
                    obj.Addresses = _Addresses.Count > 0 ? _Addresses : null;

                    var _Memberships = GetProviderMemberShip(ds, obj.ProviderId);
                    obj.Memberships = _Memberships.Count > 0 ? _Memberships : null;

                    var _Phones = GetProviderPhones(ds, obj.ProviderId);
                    obj.Phones = _Phones.Count > 0 ? _Phones : null;

                    var _Questions = GetProviderQuestions(ds, obj.ProviderId);
                    obj.Questions = _Questions.Count > 0 ? _Questions : null;

                    var _Category = GetProviderCategory(ds, obj.ProviderId);
                    obj.Category = _Category.Count > 0 ? _Category : null;

                    obj.WelcomeTitle = objCustomerAPI.WelcomeTitle;
                    obj.Instruction = objCustomerAPI.Instruction;
                    obj.TermsOfServiceValue = objCustomerAPI.TermsOfServiceValue;
                    obj.PrivacyPolicyValue = objCustomerAPI.PrivacyPolicyValue;
                    lstmodel.Add(obj);
                    #endregion
                }

            }

            #endregion



              

            return lstmodel;
        }

        private List<APIProviderAddress> GetProviderAddresses(DataSet ds, string ProviderId)
        {
            #region Bind address table field
            List<APIProviderAddress> lstResult = new List<APIProviderAddress>();
            if (ds != null && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
            {
                APIProviderAddress obj = new APIProviderAddress();
                String condition = String.Format("ProviderId = '{0}'", ProviderId);
                foreach (DataRow tblProviderAddress in ds.Tables[2].Select(condition))
                {
                    #region fill Provider Address table property
                    // obj.ProviderId = SafeValue<string>(tblProviderAddress["ProviderId"]);
                    obj.Address = SafeValue<string>(tblProviderAddress["Address"]);
                    obj.AddressId = SafeValue<string>(tblProviderAddress["AddressId"]);
                    obj.AddressType = SafeValue<string>(tblProviderAddress["AddressTypeName"]);
                    obj.Attention = SafeValue<string>(tblProviderAddress["Attention"]);
                    obj.City = SafeValue<string>(tblProviderAddress["City"]);
                    obj.State = SafeValue<string>(tblProviderAddress["State"]);
                    obj.ModifiedDate = SetModifiedDate(SafeValue<DateTime>(tblProviderAddress["ModifiedDate"]));
                    obj.CreatedDate = SafeValue<DateTime>(tblProviderAddress["CreatedDate"]);
                    obj.UntilDate = SetModifiedDate(SafeValue<DateTime>(tblProviderAddress["UntilDate"]));
                    obj.Latitude = SafeValue<float?>(tblProviderAddress["Latitude"]);
                    obj.Longitude = SafeValue<float?>(tblProviderAddress["Longitude"]);
                    lstResult.Add(obj);
                    #endregion
                }

            }
            #endregion
            return lstResult;
        }

        private List<APIProviderMembership> GetProviderMemberShip(DataSet ds, string ProviderId)
        {
            #region Bind Provider Membership table field
            List<APIProviderMembership> lstResult = new List<APIProviderMembership>();

            if (ds != null && ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
            {
                APIProviderMembership obj = new APIProviderMembership();
                String condition = String.Format("ProviderId = '{0}'", ProviderId);
                foreach (DataRow tblProviderMembership in ds.Tables[3].Select(condition))
                {
                    #region fill result set
                    obj.MembershipType = SafeValue<string>(tblProviderMembership["MembershipType"]);
                    obj.MembershipNumber = SafeValue<string>(tblProviderMembership["MembershipNumber"]);
                    obj.CreatedDate = SafeValue<DateTime>(tblProviderMembership["CreatedDate"]);
                    obj.ModifiedDate = SetModifiedDate(SafeValue<DateTime>(tblProviderMembership["ModifiedDate"]));
                    obj.UntilDate = SetModifiedDate(SafeValue<DateTime>(tblProviderMembership["UntilDate"]));
                    obj.Issuer = SafeValue<string>(tblProviderMembership["Issuer"]);
                    obj.FullName = SafeValue<string>(tblProviderMembership["FullName"]);
                    obj.Abbreviation = SafeValue<string>(tblProviderMembership["Abbreviation"]);
                    lstResult.Add(obj);
                    #endregion
                }

            }

            #endregion
            return lstResult;
        }

        private List<APIProviderPhone> GetProviderPhones(DataSet ds, string ProviderId)
        {
            #region Bind provider Phone
            List<APIProviderPhone> lstResult = new List<APIProviderPhone>();

            if (ds != null && ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
            {
                APIProviderPhone obj = new APIProviderPhone();
                String condition = String.Format("ProviderId = '{0}'", ProviderId);
                foreach (DataRow row in ds.Tables[4].Select(condition))
                {
                    obj.PhoneId = SafeValue<string>(row["PhoneId"]);
                    obj.PhoneType = SafeValue<string>(row["PhoneTypeName"]);
                    obj.CreatedDate = SafeValue<DateTime>(row["CreatedDate"]);
                    obj.ModifiedDate = SetModifiedDate(SafeValue<DateTime>(row["ModifiedDate"]));
                    obj.UntilDate = SetModifiedDate(SafeValue<DateTime>(row["UntilDate"]));
                    obj.PhoneNumber = SafeValue<string>(row["PhoneNumber"]);
                    obj.Extension = SafeValue<string>(row["Extension"]);
                    lstResult.Add(obj);
                }

            }

            #endregion
            return lstResult;
        }

        private List<APIProviderQuestions> GetProviderQuestions(DataSet ds, string ProviderId)
        {
            #region Bind provider question
            List<APIProviderQuestions> lstResult = new List<APIProviderQuestions>();

            if (ds != null && ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
            {
                APIProviderQuestions obj = new APIProviderQuestions();
                String condition = String.Format("ProviderId = '{0}'", ProviderId);
                foreach (DataRow row in ds.Tables[5].Select(condition))
                {
                    obj.QuestionId = SafeValue<int>(row["QuestionId"]);
                    obj.CategoryId = SafeValue<int>(row["ProfileDefinitionId"]);
                    obj.CategoryName = SafeValue<string>(row["ProfileDefinitionName"]);
                    obj.QuestionText = SafeValue<string>(row["QuestionText"]);
                    obj.QuestionType = SafeValue<string>(row["QuestionTypeKey"]);
                    obj.CreatedDate = SafeValue<DateTime>(row["CreatedDate"]);
                    obj.ModifiedDate = SetModifiedDate(SafeValue<DateTime>(row["ModifiedDate"]));
                    obj.Answer = GetProviderAnswer(ds, ProviderId, obj.QuestionId);

                    var _Answers = GetProviderAnswers(ds, ProviderId, obj.QuestionId);
                    obj.Answers = _Answers.Count > 0 ? _Answers : null;

                    lstResult.Add(obj);
                }

            }

            #endregion
            return lstResult;
        }

        private string GetProviderAnswer(DataSet ds, string ProviderId, int QuestionId)
        {
            string questionTypeKey = string.Empty;

            if (ds != null && ds.Tables[6] != null && ds.Tables[6].Rows.Count > 0)
            {
                String condition = String.Format("QuestionId = '{0}'", QuestionId);
                foreach (DataRow row in ds.Tables[6].Select(condition))
                {
                    questionTypeKey = SafeValue<string>(row["QuestionTypeKey"]);
                }
            }

            List<string> extractQuestionTypes = new List<string>() { "textfield", "textarea", "email", "date", "terms", "website", "yesno", "rating", "opinionscale", "number" };
            if (extractQuestionTypes.Contains(questionTypeKey, StringComparer.OrdinalIgnoreCase))
            {

                if (ds != null && ds.Tables[7] != null && ds.Tables[7].Rows.Count > 0)
                {
                    String condition = String.Format("ProviderId = '{0}' AND QuestionId = '{1}'", ProviderId, QuestionId);
                    foreach (DataRow row in ds.Tables[7].Select(condition))
                    {
                        switch (questionTypeKey)
                        {
                            case "textfield":
                                return SafeValue<string>(row["PropertyShortText"]);
                            case "textarea":
                                return SafeValue<string>(row["PropertyLongText"]);
                            case "email":
                                return SafeValue<string>(row["PropertyShortText"]);
                            case "date":
                                return SafeValue<string>(row["PropertyDateTime"]);
                            case "terms":
                                return SafeValue<string>(row["PropertyLongText"]);
                            case "website":
                                return SafeValue<string>(row["PropertyShortText"]);
                            case "yesno":
                                if (SafeValue<bool?>(row["PropertyBool"]) != null)
                                {
                                    bool dataValue = SafeValue<bool?>(row["PropertyBool"]) ?? false;
                                    return dataValue ? "True" : "False";
                                }
                                return null;
                            case "rating":
                            case "opinionscale":
                            case "number":
                                if (SafeValue<int?>(row["PropertyInt"]) != null)
                                {
                                    int dataValue = SafeValue<int?>(row["PropertyInt"]) ?? 0;
                                    return Convert.ToString(dataValue);
                                }
                                return null;
                            default:
                                break;
                        }
                    }
                }
            }
            return null;
        }

        private List<APIProviderAnswers> GetProviderAnswers(DataSet ds, string ProviderId, int QuestionId)
        {
            List<APIProviderAnswers> lstResult = new List<APIProviderAnswers>();
            string questionTypeKey = string.Empty;
            if (ds != null && ds.Tables[6] != null && ds.Tables[6].Rows.Count > 0)
            {
                String condition = String.Format("QuestionId = '{0}'", QuestionId);
                foreach (DataRow row in ds.Tables[6].Select(condition))
                {
                    questionTypeKey = SafeValue<string>(row["QuestionTypeKey"]);
                }
            }

            List<string> extractQuestionTypes = new List<string>() { "dropdown", "list", "radio" };
            if (extractQuestionTypes.Contains(questionTypeKey, StringComparer.OrdinalIgnoreCase))
            {

                if (ds != null && ds.Tables[8] != null && ds.Tables[8].Rows.Count > 0)
                {
                    String condition = String.Format("ProviderId = '{0}' AND QuestionId = '{1}'", ProviderId, QuestionId);
                    foreach (DataRow row in ds.Tables[8].Select(condition))
                    {
                        lstResult.Add(new APIProviderAnswers() { AnswerOption = SafeValue<string>(row["ResponseOptionText"]) });
                    }
                }


            }


            return lstResult;
        }
        private List<Category> GetProviderCategory(DataSet ds, string ProviderId)
        {

            #region Bind provide category
            List<Category> lstResult = new List<Category>();
            if (ds != null && ds.Tables[9] != null && ds.Tables[9].Rows.Count > 0)
            {
                Category obj = new Category();
                String condition = String.Format("ProviderId = '{0}'", ProviderId);
                foreach (DataRow row in ds.Tables[9].Select(condition))
                {
                    obj.CategoryID = SafeValue<int>(row["ProfileDefinitionId"]);
                    obj.CategoryName = SafeValue<string>(row["ProfileDefinitionName"]);
                    lstResult.Add(obj);
                }

            }
            #endregion
            return lstResult;
        }

        private DateTime? SetModifiedDate(DateTime modifiedDate)
        {
            if (modifiedDate != DateTime.MinValue)
                return modifiedDate;
            return null;
        }
    }
}
