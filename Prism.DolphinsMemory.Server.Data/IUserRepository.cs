// -----------------------------------------------------------------------
//  <copyright file="IUserRepository.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Data
{
    using System;

    /// <summary>
    /// All method to access the user
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The user id</returns>
        Guid GetUserId(string userName);
    }
}