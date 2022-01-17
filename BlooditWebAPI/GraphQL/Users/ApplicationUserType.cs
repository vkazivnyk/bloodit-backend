using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
using BlooditData.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Users
{
    public class ApplicationUserType : ObjectType<ApplicationUser>
    {
        protected override void Configure(IObjectTypeDescriptor<ApplicationUser> descriptor)
        {
            descriptor.Description("Represents the type for an application user.");

            descriptor
                .Field(u => u.AccessFailedCount)
                .Ignore();

            descriptor
                .Field(u => u.ConcurrencyStamp)
                .Ignore();

            descriptor
                .Field(u => u.EmailConfirmed)
                .Ignore();

            descriptor
                .Field(u => u.LockoutEnabled)
                .Ignore();

            descriptor
                .Field(u => u.LockoutEnd)
                .Ignore();

            descriptor
                .Field(u => u.NormalizedEmail)
                .Ignore();

            descriptor
                .Field(u => u.NormalizedUserName)
                .Ignore();

            descriptor
                .Field(u => u.PasswordHash)
                .Ignore();

            descriptor
                .Field(u => u.PhoneNumber)
                .Ignore();

            descriptor
                .Field(u => u.PhoneNumberConfirmed)
                .Ignore();

            descriptor
                .Field(u => u.SecurityStamp)
                .Ignore();

            descriptor
                .Field(u => u.TwoFactorEnabled)
                .Ignore();

            descriptor
                .Field(u => u.UserTopics)
                .Ignore();

            descriptor
                .Field(u => u.Posts)
                .ResolveWith<Resolvers>(r => r.GetPost(default, default));

            descriptor
                .Field(u => u.Comments)
                .ResolveWith<Resolvers>(r => r.GetComment(default, default));

            base.Configure(descriptor);
        }

        private class Resolvers
        {
            public IEnumerable<Post> GetPost(ApplicationUser user, [Service] IAppRepository repository)
            {
                return repository.GetPostsByUserId(user.Id);
            }

            public IEnumerable<Comment> GetComment(ApplicationUser user, [Service] IAppRepository repository)
            {
                return repository.GetCommentsByUserId(user.Id);
            }
        }
    }
}
