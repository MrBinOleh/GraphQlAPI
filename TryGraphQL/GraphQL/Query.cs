using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using TryGraphQL.Data;
using TryGraphQL.Models;

namespace TryGraphQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        //[UseProjection]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Platforms;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        //[UseProjection]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Commands;
        }
    }
}