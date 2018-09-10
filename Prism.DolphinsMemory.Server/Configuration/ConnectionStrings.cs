// -----------------------------------------------------------------------
//  <copyright file="ConnectionStrings.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Configuration
{
    using System;
    using System.Linq;

    /// <summary>
    /// Configuration of the connection strings
    /// </summary>
    public class ConnectionStrings
    {
        /// <summary>
        /// Gets or sets the default connection.
        /// </summary>
        /// <value>
        /// The default connection.
        /// </value>
        public string DefaultConnection { get; set; }
    }
}