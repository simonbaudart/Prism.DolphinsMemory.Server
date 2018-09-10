// -----------------------------------------------------------------------
//  <copyright file="ISecurityDomain.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Business
{
    using System;
    using System.Linq;

    /// <summary>
    /// All methods related to security
    /// </summary>
    public interface ISecurityDomain
    {
        /// <summary>
        /// Adds the authentication password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The iterations.</param>
        void AddAuthenticationPassword(string userName, byte[] hash, byte[] salt, int iterations);

        /// <summary>
        /// Generates the password.
        /// </summary>
        /// <returns>A new password</returns>
        string GeneratePassword();

        /// <summary>
        /// Generates the salt.
        /// </summary>
        /// <returns>A byte that is the salt</returns>
        byte[] GenerateSalt();

        /// <summary>
        /// Hashes the specified password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The number of iterations.</param>
        /// <returns>
        /// The hashed password
        /// </returns>
        byte[] Hash(string password, byte[] salt, int iterations);
    }
}