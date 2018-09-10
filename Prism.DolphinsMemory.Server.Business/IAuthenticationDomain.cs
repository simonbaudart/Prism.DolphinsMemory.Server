// -----------------------------------------------------------------------
//  <copyright file="IAuthenticationDomain.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Business
{
    using System;

    using Prism.DolphinsMemory.Server.Model;

    /// <summary>
    /// All method for authentication
    /// </summary>
    public interface IAuthenticationDomain
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The user id from the user</returns>
        Guid GetUserId(string userName);

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="authentication">The authentication.</param>
        /// <returns>A bearer associated with the user</returns>
        string ValidateUser(UserAuthentication authentication);
    }
}