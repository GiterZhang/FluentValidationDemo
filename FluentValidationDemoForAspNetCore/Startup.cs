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
using Swashbuckle.AspNetCore.Swagger;

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
            .AddFluentValidation(fv => {
                fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });
            ;
            services.AddSingleton(typeof(IPersonService), typeof(PersonService));
            //services.AddSingleton(typeof(IValidator<AddPersonInput>), typeof(AddPersonInputValidator));
            //services.AddSingleton(typeof(IValidator<AddStudentInput>), typeof(AddStudentInputValidator));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
