using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedResources.DTOs;
using SharedResources.Resolvers;
using System;

namespace HC_V11
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(
               builder => builder.SetIsOriginAllowed(uriOrigin =>
               {
                   if (!Uri.TryCreate(uriOrigin, UriKind.RelativeOrAbsolute, out var uri))
                       return false;

                   return uri.IsLoopback;
               })
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
           ));

            var exeDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var fullSchemaFilePath = System.IO.Path.Combine(exeDir!, @"OneSchemaToRuleThemAll.graphql");

            services
                .AddSingleton<PersonRepository>()
                .AddGraphQLServer()
                .AddDocumentFromFile(fullSchemaFilePath)
                .BindComplexType<Query>()
                .BindComplexType<PersonInput>()
                .BindComplexType<PersonPayload>()
                .BindComplexType<Student>()
                .BindComplexType<Teacher>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
