// -----------------------------------------------------------------------
//  <copyright file="LoginController.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Api.Controllers
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Prism.DolphinsMemory.Server.Business;
    using Prism.DolphinsMemory.Server.Model;

    /// <summary>
    /// Authentication methods
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class LoginController : BaseController
    {
        /// <summary>
        /// The authentication domain
        /// </summary>
        private readonly IAuthenticationDomain authenticationDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController" /> class.
        /// </summary>
        /// <param name="authenticationDomain">The authentication domain.</param>
        public LoginController(IAuthenticationDomain authenticationDomain)
        {
            this.authenticationDomain = authenticationDomain;
        }

        /// <summary>
        /// Authenticates the with password.
        /// </summary>
        /// <param name="authentication">The authentication.</param>
        /// <returns>The bearer to use in next requests</returns>
        [Route("api/login/authenticate-with-password")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AuthenticateWithPassword([FromBody] UserAuthentication authentication)
        {
            this.EnsureModelState();

            var bearer = this.authenticationDomain.ValidateUser(authentication);

            if (string.IsNullOrWhiteSpace(bearer))
            {
                return this.NotFound();
            }

            return new JsonResult(new AuthenticationBearer { Bearer = bearer });
        }
    }
}