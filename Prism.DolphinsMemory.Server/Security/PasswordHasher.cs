// -----------------------------------------------------------------------
//  <copyright file="PasswordHasher.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Security
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Cryptography.KeyDerivation;

    /// <summary>
    /// Hash the passwords !
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Hashes the specified password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The iterations.</param>
        /// <returns>The hashed password</returns>
        public static byte[] Hash(string password, byte[] salt, int iterations)
        {
            return KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA512,
                iterations,
                256 / 8);
        }
    }
}