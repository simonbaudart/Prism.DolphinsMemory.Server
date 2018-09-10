// -----------------------------------------------------------------------
//  <copyright file="BaseController.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Base class for all controllers
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        protected Guid UserId => this.User.Identity.IsAuthenticated ? Guid.Parse(this.User.FindFirst(ClaimTypes.Sid).Value) : default(Guid);

        /// <summary>
        /// Ensures the state of the model.
        /// </summary>
        /// <exception cref="System.ApplicationException">Your model is not valid</exception>
        protected void EnsureModelState()
        {
            if (!this.ModelState.IsValid)
            {
                throw new ApplicationException("Your model is not valid");
            }
        }
    }
}