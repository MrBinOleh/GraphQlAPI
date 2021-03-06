using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using TryGraphQL.Data;
using TryGraphQL.Models;

namespace TryGraphQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Some description for Platform.");
            
            descriptor.Field(p => p.LicenseKey).Ignore();

            descriptor
                .Field(p => p.Commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>();
        }
        
        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext dbContext)
            {
                return dbContext.Commands.Where(c => c.PlatformId == platform.Id);
            }
        }
    }
}