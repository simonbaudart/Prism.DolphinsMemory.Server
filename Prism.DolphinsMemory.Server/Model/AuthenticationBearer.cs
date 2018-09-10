// -----------------------------------------------------------------------
//  <copyright file="AuthenticationBearer.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Model
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represent an authentication bearer
    /// </summary>
    [DataContract]
    public class AuthenticationBearer
    {
        /// <summary>
        /// Gets or sets the bearer.
        /// </summary>
        /// <value>
        /// The bearer.
        /// </value>
        [DataMember(Name = "bearer")]
        public string Bearer { get; set; }
    }
}