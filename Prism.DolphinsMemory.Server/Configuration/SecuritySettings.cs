// -----------------------------------------------------------------------
//  <copyright file="SecuritySettings.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Configuration
{
    using System;
    using System.Linq;

    /// <summary>
    /// All security settings
    /// </summary>
    public class SecuritySettings
    {
        /// <summary>
        /// Gets or sets the bearer derivation key.
        /// </summary>
        /// <value>
        /// The bearer derivation key.
        /// </value>
        public string BearerDerivationKey { get; set; }

        /// <summary>
        /// Gets or sets the issuer.
        /// </summary>
        /// <value>
        /// The issuer.
        /// </value>
        public string Issuer { get; set; }
    }
}