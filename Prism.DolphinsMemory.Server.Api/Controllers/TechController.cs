// -----------------------------------------------------------------------
//  <copyright file="TechController.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Api.Controllers
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    using Prism.DolphinsMemory.Server.Business;
    using Prism.DolphinsMemory.Server.Model;

    /// <summary>
    /// Class to manage all dev tests
    /// </summary>
    public class TechController : BaseController
    {
        /// <summary>
        /// The security domain
        /// </summary>
        private readonly ISecurityDomain securityDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="TechController" /> class.
        /// </summary>
        /// <param name="env">The env.</param>
        /// <param name="securityDomain">The security domain.</param>
        /// <exception cref="NotSupportedException">You cannot use this controller in production</exception>
        public TechController(IHostingEnvironment env, ISecurityDomain securityDomain)
        {
            if (env.IsProduction())
            {
                throw new NotSupportedException("You cannot use this controller in production");
            }

            this.securityDomain = securityDomain;
        }

        /// <summary>
        /// Resets the authentication password.
        /// </summary>
        /// <param name="userName">The user identifier.</param>
        /// <returns>The new password</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("api/tech/reset-authentication-password/{userName}")]
        public IActionResult ResetAuthenticationPassword(string userName)
        {
            var newPassword = this.securityDomain.GeneratePassword();
            var salt = this.securityDomain.GenerateSalt();
            var hash = this.securityDomain.Hash(newPassword, salt, 10000);

            this.securityDomain.AddAuthenticationPassword(userName, hash, salt, 10000);

            return new JsonResult(new UserAuthentication { UserName = userName, Password = newPassword });
        }
    }
}