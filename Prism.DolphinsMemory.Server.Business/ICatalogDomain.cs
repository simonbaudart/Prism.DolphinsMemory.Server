// -----------------------------------------------------------------------
//  <copyright file="ICatalogDomain.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Prism.DolphinsMemory.Server.Model;

    /// <summary>
    /// Manage the catalogs
    /// </summary>
    public interface ICatalogDomain
    {
        /// <summary>
        /// Gets the catalogs.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>All catalogs for the user</returns>
        List<Catalog> GetCatalogs(Guid userId);
    }
}