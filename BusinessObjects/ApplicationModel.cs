﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	/// <summary>
	/// Required parameter for get application list.
	/// </summary>
	public class ApplicationParamModel
    {
		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>
		/// The name of the user.
		/// </value>
		[Required]
		public string UserName { get; set; }
    }

	/// <summary>
	/// Application model property.
	/// </summary>
	public class ApplicationResultModel
    {
		/// <summary>
		/// Gets or sets the application identifier.
		/// </summary>
		/// <value>
		/// The application identifier.
		/// </value>
		public int ApplicationId { get; set; }

		/// <summary>
		/// Gets or sets the name of the application.
		/// </summary>
		/// <value>
		/// The name of the application.
		/// </value>
		public string ApplicationName { get; set; }

		/// <summary>
		/// Gets or sets the application desc.
		/// </summary>
		/// <value>
		/// The application desc.
		/// </value>
		public string ApplicationDesc { get; set; }

		/// <summary>
		/// Gets or sets the application logo.
		/// </summary>
		/// <value>
		/// The application logo.
		/// </value>
		public string ApplicationLogo { get; set; }

		/// <summary>
		/// Gets or sets the application code.
		/// </summary>
		/// <value>
		/// The application code.
		/// </value>
		public string ApplicationCode { get; set; }

		/// <summary>
		/// Gets or sets the display order.
		/// </summary>
		/// <value>
		/// The display order.
		/// </value>
		public int DisplayOrder { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is active.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
		/// </value>
		public bool IsActive { get; set; }

		/// <summary>
		/// Gets or sets the created by.
		/// </summary>
		/// <value>
		/// The created by.
		/// </value>
		public int CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the created on.
		/// </summary>
		/// <value>
		/// The created on.
		/// </value>
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// Gets or sets the modified by.
		/// </summary>
		/// <value>
		/// The modified by.
		/// </value>
		public int ModifiedBy { get; set; }

		/// <summary>
		/// Gets or sets the modified on.
		/// </summary>
		/// <value>
		/// The modified on.
		/// </value>
		public DateTime ModifiedOn { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is deleted.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
		/// </value>
		public bool IsDeleted { get; set; }

		/// <summary>
		/// Gets or sets the deleted on.
		/// </summary>
		/// <value>
		/// The deleted on.
		/// </value>
		public DateTime DeletedOn { get; set; }

		/// <summary>
		/// Gets or sets the application domain.
		/// </summary>
		/// <value>
		/// The application domain.
		/// </value>
		public string ApplicationDomain { get; set; }
	}
}
