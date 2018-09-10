// -----------------------------------------------------------------------
//  <copyright file="ICatalogRepository.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Prism.DolphinsMemory.Server.Model;

    /// <summary>
    /// Gets the catalogs
    /// </summary>
    public interface ICatalogRepository
    {
        /// <summary>
        /// Deletes the catalog.
        /// </summary>
        /// <param name="catalogId">The catalog identifier.</param>
        void DeleteCatalog(Guid catalogId);

        /// <summary>
        /// Gets the catalogs.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>List of all catalogs</returns>
        List<Catalog> GetCatalogs(Guid userId);

        /// <summary>
        /// Determines whether the catalog belongs to the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="catalogId">The catalog identifier.</param>
        /// <returns>
        /// <c>true</c> if  the catalog belongs to the user; otherwise, <c>false</c>.
        /// </returns>
        bool IsMyCatalog(Guid userId, Guid catalogId);

        /// <summary>
        /// Update or insert the catalog.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="catalog">The catalog.</param>
        void UpsertCatalog(Guid userId, Catalog catalog);
    }
}