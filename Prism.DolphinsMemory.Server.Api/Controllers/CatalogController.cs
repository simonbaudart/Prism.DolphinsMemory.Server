// -----------------------------------------------------------------------
//  <copyright file="CatalogController.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Api.Controllers
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using Prism.DolphinsMemory.Server.Business;

    /// <summary>
    /// Manage the catalogs
    /// </summary>
    /// <seealso cref="Prism.DolphinsMemory.Server.Api.Controllers.BaseController" />
    public class CatalogController : BaseController
    {
        /// <summary>
        /// The catalog domain
        /// </summary>
        private readonly ICatalogDomain catalogDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogController" /> class.
        /// </summary>
        /// <param name="catalogDomain">The catalog domain.</param>
        public CatalogController(ICatalogDomain catalogDomain)
        {
            this.catalogDomain = catalogDomain;
        }

        /// <summary>
        /// Gets the catalogs.
        /// </summary>
        /// <returns>All th catalogs</returns>
        [Route("api/catalogs")]
        [HttpGet]
        public IActionResult GetCatalogs()
        {
            return this.Json(this.catalogDomain.GetCatalogs(this.UserId));
        }
    }
}