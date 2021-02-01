using System;
using System.Collections.Generic;

namespace CarelikeAPI.Models
{
    

    public class APIResult
    {
        public List<APIProvider> Provider { get; set; }
    }

    
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
     

    public class APIProvider
    {
        public string ProviderId { get; set; }
        public int PartyId { get; set; }
        public string DBAName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<System.DateTime> UntilDate { get; set; }
        public string FKAName { get; set; }
        public string LAName { get; set; }
        public List<APIProviderAddress> Addresses { get; set; }
        public List<APIProviderMembership> Memberships { get; set; }
        public List<APIProviderPhone> Phones { get; set; }
        public List<APIProviderQuestions> Questions { get; set; }
        public List<Category> Category { get; set; }
        //public string PortalURL { get; set; }
        //public string UploadLogo { get; set; }
        public string WelcomeTitle { get; set; }
        public string Instruction { get; set; }
        //public bool ShowAdvancedfilters { get; set; }
        //public bool DisplayCarematch { get; set; }
        public string ListingIntro { get; set; }
        //public string TermsOfServiceType { get; set; }
        //public string PrivacyPolicyType { get; set; }
        public string TermsOfServiceValue { get; set; }
        public string PrivacyPolicyValue { get; set; }
    }
     

    public class APIProviderAddress
    {
        public string AddressId { get; set; }
        //public int AddressTypeId { get; set; }
        public string AddressType { get; set; }
        public string Attention { get; set; }
        public string Address { get; set; }
        public string AptOrSuite { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<System.DateTime> UntilDate { get; set; }
    }

    

    public class APIProviderMembership
    {
        //public int ProviderMembershipId { get; set; }
        //public int MembershipId { get; set; }
        public string MembershipType { get; set; }
        public string MembershipNumber { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<System.DateTime> UntilDate { get; set; }
        public string Issuer { get; set; }
        public string FullName { get; set; }
        public string Abbreviation { get; set; }
    }

     
    public class APIProviderPhone
    {
        public string PhoneId { get; set; }
        //public int PhoneTypeId { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public Nullable<System.DateTime> UntilDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }

   

    public class APIProviderQuestions
    {
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string Answer { get; set; }
        public List<APIProviderAnswers> Answers { get; set; }
    }

     

    public class APIProviderAnswers
    {
        public string AnswerOption { get; set; }
    }
    #region Dynamic API
    public class Address
    {
        public string Addresses_AddressId { get; set; }
        public string Addresses_CreatedDate { get; set; }
        public string Addresses_ModifiedDate { get; set; }
        public string Addresses_UntilDate { get; set; }
        public string Addresses_AddressTypeId { get; set; }
        public string Addresses_AddressType { get; set; }
        public string Addresses_Attention { get; set; }
        public string Addresses_Address { get; set; }
        public string Addresses_AptOrSuite { get; set; }
        public string Addresses_PostalCode { get; set; }
        public string Addresses_City { get; set; }
        public string Addresses_State { get; set; }
    }

    public class Phone
    {
        public string Phones_PhoneId { get; set; }
        public string Phones_PhoneTypeId { get; set; }
        public string Phones_PhoneType { get; set; }
        public string Phones_PhoneNumber { get; set; }
        public string Phones_Extension { get; set; }
        public string Phones_UntilDate { get; set; }
        public string Phones_CreatedDate { get; set; }
        public string Phones_ModifiedDate { get; set; }
    }

    public class QuestionsAnswer
    {
        public string Answers_ProviderProfilePropertyId { get; set; }
        public string Answers_PropertyMultiOption { get; set; }
        public string Answers_CreatedDate { get; set; }
        public string Answers_ModifiedDate { get; set; }
        public string Answers_UntilDate { get; set; }
        public string Answers_ProviderProfileId { get; set; }
        public string Answers_QuestionId { get; set; }
        public string Answers_PropertyBool { get; set; }
        public string Answers_PropertyInt { get; set; }
        public string Answers_PropertyDateTime { get; set; }
        public string Answers_PropertyDecimal { get; set; }
        public string Answers_PropertyShortText { get; set; }
        public string Answers_PropertyLongText { get; set; }
    }

    public class Question
    {
        public string Questions_QuestionId { get; set; }
        public string Questions_Required { get; set; }
        public string Questions_Active { get; set; }
        public string Questions_CreatedDate { get; set; }
        public string Questions_ModifiedDate { get; set; }
        public string Questions_MinValue { get; set; }
        public string Questions_MaxValue { get; set; }
        public string Questions_QuestionDisplayText { get; set; }
        public string Questions_DisplayOrder { get; set; }
        public string Questions_QuestionKey { get; set; }
        public string Questions_IsReadOnly { get; set; }
        public string Questions_ProfileDefinitionId { get; set; }
        public string Questions_SNAP_PropertyName { get; set; }
        public string Questions_CareseekerDisplayText { get; set; }
        public string Questions_QuestionText { get; set; }
        public string Questions_QuestionDescription { get; set; }
        public string Questions_QuestionTypeId { get; set; }
        public string Questions_AllowsMultiSelect { get; set; }
        public string Questions_TextMaxLength { get; set; }
        public List<QuestionsAnswer> Questions_Answers { get; set; }
    }

    public class ProfileDefinition
    {
        public string ProfileDefinitions_ProfileDefinitionID { get; set; }
        public string ProfileDefinitions_ProfileDefinitionName { get; set; }
    }

    public class Provider
    {
        public string Provider_ProviderId { get; set; } 
        public string Provider_DBAName { get; set; }
        public string Provider_CreatedDate { get; set; }
        public string Provider_ModifiedDate { get; set; }
        public string Provider_UntilDate { get; set; }
        public string Provider_FKAName { get; set; }
        public string Provider_LAName { get; set; }
        public List<Address> Addresses { get; set; }
        public List<object> Memberships { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Question> Questions { get; set; }
        public List<ProfileDefinition> ProfileDefinitions { get; set; }
    }

    public class DynamicAPIModel
    {
        public List<Provider> Provider { get; set; }
    }


    #endregion
}