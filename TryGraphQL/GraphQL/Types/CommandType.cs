﻿using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using TryGraphQL.Data;
using TryGraphQL.Models;

namespace TryGraphQL.GraphQL.Types
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Some Command description.");

            descriptor
                .Field(p => p.Platform)
                .ResolveWith<Resolver>(p => p.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>();
        }
        
        private class Resolver
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext dbContext)
            {
                return dbContext.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}