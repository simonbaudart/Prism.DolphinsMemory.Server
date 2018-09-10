// -----------------------------------------------------------------------
//  <copyright file="UserAuthentication.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// The password for a user
    /// </summary>
    [DataContract]
    public class UserAuthentication
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [DataMember(Name = "password")]
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [Required]
        [MaxLength(250)]
        [DataMember(Name = "userName")]
        public string UserName { get; set; }
    }
}