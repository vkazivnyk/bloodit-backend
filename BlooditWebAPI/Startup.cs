using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BlooditWebAPI.GraphQL.Comments;
using BlooditWebAPI.GraphQL.Posts;
using BlooditWebAPI.GraphQL.Topics;
using BlooditWebAPI.GraphQL.Users;

namespace BlooditWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddType<ApplicationUserType>()
                .AddType<TopicType>()
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
                .AddType<CommentDeletePayloadType>();

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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
