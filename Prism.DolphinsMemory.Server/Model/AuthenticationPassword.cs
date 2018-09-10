// -----------------------------------------------------------------------
//  <copyright file="AuthenticationPassword.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Model
{
    using System;
    using System.Linq;

    /// <summary>
    /// Authentication information for user
    /// </summary>
    public class AuthenticationPassword
    {
        /// <summary>
        /// Gets or sets the hash.
        /// </summary>
        /// <value>
        /// The hash.
        /// </value>
        public byte[] Hash { get; set; }

        /// <summary>
        /// Gets or sets the iterations.
        /// </summary>
        /// <value>
        /// The iterations.
        /// </value>
        public int Iterations { get; set; }

        /// <summary>
        /// Gets or sets the salt.
        /// </summary>
        /// <value>
        /// The salt.
        /// </value>
        public byte[] Salt { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }
    }
}