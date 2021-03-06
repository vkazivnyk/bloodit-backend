using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.DbContexts;
using BlooditData.Repositories;
using BlooditWebAPI.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BlooditWebAPI.GraphQL.Comments;
using BlooditWebAPI.GraphQL.ErrorFilters;
using BlooditWebAPI.GraphQL.Extensions;
using BlooditWebAPI.GraphQL.Posts;
using BlooditWebAPI.GraphQL.Topics;
using BlooditWebAPI.GraphQL.Users;
using Microsoft.EntityFrameworkCore;

namespace BlooditWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppDb"));
            });

            services.AddScoped<IAppRepository, MockAppRepository>();

            string corsUrl = Configuration.GetSection("AllowedHosts").Value;

            services.AddCors(options =>
            {
                options.AddPolicy("Default", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(origin => new Uri(origin).Host == corsUrl);
                });
            });

            services
                .AddGraphQLServer()
                .AddType<ApplicationUserType>()
                .AddTypeExtension<ApplicationUserTypeExtensions>()
                .AddType<TopicType>()
                .AddTypeExtension<TopicTypeExtensions>()
                .AddType<TopicAddInputType>()
                .AddType<TopicAddPayloadType>()
                .AddType<PostType>()
                .AddType<PostAddInputType>()
                .AddType<PostAddPayloadType>()
                .AddType<PostDeleteInputType>()
                .AddType<PostDeletePayloadType>()
                .AddType<CommentType>()
                .AddType<CommentAddInputType>()
                .AddType<CommentAddPayloadType>()
                .AddType<CommentDeleteInputType>()
                .AddType<CommentDeletePayloadType>()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddErrorFilter<GraphQLErrorFilter>()
                .AddFiltering()
                .AddSorting();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlooditWebAPI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlooditWebAPI v1"));
            }

            app.UseCors("Default");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapControllers();
            });
        }
    }
}
