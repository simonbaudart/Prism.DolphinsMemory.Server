// -----------------------------------------------------------------------
//  <copyright file="BaseController.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Api.Controllers
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Base class for all controllers
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public abstract class BaseController : Controller
    {
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