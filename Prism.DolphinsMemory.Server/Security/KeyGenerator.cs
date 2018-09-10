// -----------------------------------------------------------------------
//  <copyright file="KeyGenerator.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Security
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public static class KeyGenerator
    {
        /// <summary>
        /// Gets the encrypt byte key.
        /// </summary>
        /// <param name="keyForDerivation">The key for derivation.</param>
        /// <returns>The encrypt key derived from key</returns>
        public static byte[] GetEncryptByteKey(string keyForDerivation)
        {
            var salt = new string(keyForDerivation.Reverse().ToArray());
            var derivation = new Rfc2898DeriveBytes(keyForDerivation, Encoding.Default.GetBytes(salt), 42);
            return derivation.GetBytes(256 / 8);
        }

        /// <summary>
        /// Gets the signin byte key.
        /// </summary>
        /// <param name="keyForDerivation">The key for derivation.</param>
        /// <returns>The sign byte key</returns>
        public static byte[] GetSigninByteKey(string keyForDerivation)
        {
            var salt = new string(keyForDerivation.Reverse().ToArray());
            var derivation = new Rfc2898DeriveBytes(keyForDerivation, Encoding.Default.GetBytes(salt), 42);
            return derivation.GetBytes(256 / 8);
        }
    }
}