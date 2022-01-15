using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
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

            // TODO: add resolvers

            base.Configure(descriptor);
        }
    }
}
