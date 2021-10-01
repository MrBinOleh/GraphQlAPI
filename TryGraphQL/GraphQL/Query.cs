﻿using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using TryGraphQL.Data;
using TryGraphQL.Models;

namespace TryGraphQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Platforms;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Commands;
        }
    }
}