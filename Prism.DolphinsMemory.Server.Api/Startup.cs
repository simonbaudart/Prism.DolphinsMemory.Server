// -----------------------------------------------------------------------
//  <copyright file="Startup.cs" company="Prism">
//  Copyright (c) Prism. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.DolphinsMemory.Server.Api
{
    using System;
    using System.Linq;
    using System.Text;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    using Prism.DolphinsMemory.Server.Business;
    using Prism.DolphinsMemory.Server.Business.Concrete;
    using Prism.DolphinsMemory.Server.Configuration;
    using Prism.DolphinsMemory.Server.Data;
    using Prism.DolphinsMemory.Server.Data.Sql;
    using Prism.DolphinsMemory.Server.Security;

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

            app.UseAuthentication();
            app.UseMvc();
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            var signingKey = new SymmetricSecurityKey(KeyGenerator.GetSigninByteKey(this.configuration["Security:BearerDerivationKey"]));
            var cryptKey = new SymmetricSecurityKey(KeyGenerator.GetEncryptByteKey(this.configuration["Security:BearerDerivationKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                                                                    {
                                                                        ValidateIssuer = true,
                                                                        ValidateAudience = true,
                                                                        ValidateLifetime = true,
                                                                        ValidateIssuerSigningKey = true,
                                                                        ValidIssuer = this.configuration["Security:Issuer"],
                                                                        ValidAudience = "api://default",
                                                                        IssuerSigningKey = signingKey,
                                                                        TokenDecryptionKey = cryptKey
                                                                    };
                        });

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
            services.AddScoped<IAuthenticationDomain, AuthenticationDomain>();
            services.AddScoped<ISecurityDomain, SecurityDomain>();
        }

        /// <summary>
        /// Configures the config services.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureConfigurationServices(IServiceCollection services)
        {
            services.Configure<ConnectionStrings>(this.configuration.GetSection("ConnectionStrings"));
            services.Configure<SecuritySettings>(this.configuration.GetSection("Security"));
        }

        /// <summary>
        /// Configures the data services.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureDataServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}