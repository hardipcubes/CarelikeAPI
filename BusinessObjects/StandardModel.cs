using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{

    #region Internal Model
    public class TblCustomerAPI
    {
        /// <summary>
        /// Gets or sets the API identifier.
        /// </summary>
        /// <value>
        /// The API identifier.
        /// </value>
        public int APIId { get; set; }

        /// <summary>
        /// Gets or sets the welcome title.
        /// </summary>
        /// <value>
        /// The welcome title.
        /// </value>
        public string WelcomeTitle { get; set; }
        /// <summary>
        /// Gets or sets the instruction.
        /// </summary>
        /// <value>
        /// The instruction.
        /// </value>
        public string Instruction { get; set; }
        /// <summary>
        /// Gets or sets the privacy policy value.
        /// </summary>
        /// <value>
        /// The privacy policy value.
        /// </value>
        public string PrivacyPolicyValue { get; set; }
        /// <summary>
        /// Gets or sets the terms of service value.
        /// </summary>
        /// <value>
        /// The terms of service value.
        /// </value>
        public string TermsOfServiceValue { get; set; }
        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime FromDate { get; set; }
        /// <summary>
        /// Converts to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public DateTime ToDate { get; set; }

    }
     
    #endregion
    public class StandardAPIRequestModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the provider identifier.
        /// </summary>
        /// <value>
        /// The provider identifier.
        /// </value>
        public string ProviderId { get; set; }

        /// <summary>
        /// Gets or sets the off set.
        /// </summary>
        /// <value>
        /// The off set.
        /// </value>
        public int OffSet { get; set; }

        /// <summary>
        /// If you can not parse then default 20 record featch.
        /// </summary>
        /// <value>
        /// The display record to.
        /// </value>
        public int FetchNext { get; set; }

        /// <summary>
        /// Gets or sets the date time since.
        /// </summary>
        /// <value>
        /// The date time since.
        /// </value>
        [Required]
        public DateTime DateTimeSince { get; set; }

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
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? UntilDate { get; set; }
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
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? UntilDate { get; set; }
    }

     
    public class APIProviderMembership
    {
        public string ProviderId { get; set; }
        public string MembershipType { get; set; }
        public string MembershipNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? UntilDate { get; set; }
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
        public DateTime? UntilDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }



    public class APIProviderQuestions
    {
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Answer { get; set; }
        public List<APIProviderAnswers> Answers { get; set; }
    }



    public class APIProviderAnswers
    {
        public string AnswerOption { get; set; }
    }
}
