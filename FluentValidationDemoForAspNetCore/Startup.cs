using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationDemoForAspNetCore.Input;
using FluentValidationDemoForAspNetCore.Interface;
using FluentValidationDemoForAspNetCore.Service;
using FluentValidationDemoForAspNetCore.Validator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FluentValidationDemoForAspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //.AddFluentValidation();
            ;
            services.AddSingleton(typeof(IPersonService), typeof(PersonService));
            services.AddSingleton(typeof(IValidator<AddPersonInput>), typeof(AddPersonInputValidator));
            services.AddSingleton(typeof(IValidator<AddStudentInput>), typeof(AddStudentInputValidator));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
