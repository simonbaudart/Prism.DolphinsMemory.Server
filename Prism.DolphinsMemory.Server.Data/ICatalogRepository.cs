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
        /// Gets the catalogs.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>List of all catalogs</returns>
        List<Catalog> GetCatalogs(Guid userId);
    }
}