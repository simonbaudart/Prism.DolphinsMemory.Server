﻿// -----------------------------------------------------------------------
//  <copyright file="InfoController.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Api.Controllers
{
    using System;
    using System.IO;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using Prism.DolphinsMemory.Server.Model;

    /// <summary>
    /// Controller to get most of the information about the application
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class InfoController : Controller
    {
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <returns>The version of the current assembly</returns>
        [Route("api/info/version")]
        public JsonResult GetVersion()
        {
            var version = new ApiVersion
                              {
                                  Version = typeof(InfoController).Assembly.GetName().Version.ToString(),
                                  LastUpdate = new FileInfo(typeof(InfoController).Assembly.Location).LastWriteTimeUtc
                              };

            return this.Json(version);
        }
    }
}