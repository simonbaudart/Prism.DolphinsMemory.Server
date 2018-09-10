// -----------------------------------------------------------------------
//  <copyright file="Startup.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Api
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Prism.DolphinsMemory.Server.Business;
    using Prism.DolphinsMemory.Server.Business.Concrete;
    using Prism.DolphinsMemory.Server.Configuration;
    using Prism.DolphinsMemory.Server.Data;
    using Prism.DolphinsMemory.Server.Data.Sql;

    /// <summary>
    /// Start the application
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMvc();

            this.ConfigureConfigurationServices(services);
            this.ConfigureBusinessServices(services);
            this.ConfigureDataServices(services);
        }

        /// <summary>
        /// Configures the business services.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureBusinessServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<ISecurityDomain, SecurityDomain>();
        }

        /// <summary>
        /// Configures the config services.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureConfigurationServices(IServiceCollection services)
        {
            var connectionStrings = this.configuration.GetSection("ConnectionStrings");
            services.Configure<ConnectionStrings>(connectionStrings);
        }

        /// <summary>
        /// Configures the data services.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureDataServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}