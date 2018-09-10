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
    using Prism.DolphinsMemory.Server.Model;

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

        /// <summary>
        /// Updates the catalog.
        /// </summary>
        /// <param name="catalog">The catalog.</param>
        /// <returns>Ok if catalog is updated</returns>
        [Route("api/catalogs")]
        [HttpPost]
        public IActionResult UpdateCatalog([FromBody] Catalog catalog)
        {
            this.EnsureModelState();

            this.catalogDomain.UpsertCatalog(this.UserId, catalog);

            return this.Ok();
        }

        /// <summary>
        /// Deletes the catalog.
        /// </summary>
        /// <param name="catalogId">The catalog identifier.</param>
        /// <returns>Ok if catalog is deleted</returns>
        [Route("api/catalogs/{catalogId}")]
        [HttpDelete]
        public IActionResult DeleteCatalog(Guid catalogId)
        {
            this.EnsureModelState();

            this.catalogDomain.DeleteCatalog(this.UserId, catalogId);

            return this.Ok();
        }
    }
}