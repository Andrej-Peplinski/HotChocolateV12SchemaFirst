using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedResources.DTOs;
using SharedResources.Resolvers;
using System;

namespace HC_V12_MVC
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
                .AddResolver<Query>()
                //.BindComplexType<PersonInput>()       // <- No longer necessary
                //.BindComplexType<PersonPayload>()     // <- No longer necessary

                //.BindComplexType<Student>()   -> Now replaced by...
                .AddResolver(typeName: "Student", fieldName: "firstName", resolver: context => context.Parent<Student>().FirstName)
                .AddResolver(typeName: "Student", fieldName: "lastName",  resolver: context => context.Parent<Student>().LastName)
                .AddResolver(typeName: "Student", fieldName: "grade",     resolver: context => context.Parent<Student>().Grade)

                //.BindComplexType<Teacher>()   -> Now replaced by...
                .AddResolver(typeName: "Teacher", fieldName: "firstName", resolver: context => context.Parent<Teacher>().FirstName)
                .AddResolver(typeName: "Teacher", fieldName: "lastName",  resolver: context => context.Parent<Teacher>().LastName)
                .AddResolver(typeName: "Teacher", fieldName: "subjects",  resolver: context => context.Parent<Teacher>().Subjects)
                ;
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
