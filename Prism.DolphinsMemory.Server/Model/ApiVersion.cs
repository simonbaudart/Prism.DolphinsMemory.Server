// -----------------------------------------------------------------------
//  <copyright file="ApiVersion.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Model
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represent a version
    /// </summary>
    [DataContract]
    public class ApiVersion
    {
        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>
        /// The last update.
        /// </value>
        [DataMember(Name = "lastUpdate")]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [DataMember(Name = "version")]
        public string Version { get; set; }
    }
}