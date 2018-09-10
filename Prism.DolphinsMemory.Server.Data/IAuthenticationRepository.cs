// -----------------------------------------------------------------------
//  <copyright file="IAuthenticationRepository.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Data
{
    using System;
    using System.Linq;

    /// <summary>
    /// Store data for authentication
    /// </summary>
    public interface IAuthenticationRepository
    {
        /// <summary>
        /// Update or insert the authentication password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The iterations.</param>
        void UpsertAuthenticationPassword(Guid userId, byte[] hash, byte[] salt, int iterations);
    }
}