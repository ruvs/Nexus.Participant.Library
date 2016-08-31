using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Nexus.ParticipantLibrary.Data.Context
{
    public class ParticipantLibraryContextFactory : IDbContextFactory<ParticipantLibraryContext>
    {
        public ParticipantLibraryContext Create(DbContextFactoryOptions options)
        {
            var x = options.ApplicationBasePath;
            var optionsBuilder = new DbContextOptionsBuilder<ParticipantLibraryContext>();
            optionsBuilder.UseSqlServer(@"Data Source=HV-MUFASA\DEV01;Initial Catalog=ParticipantLibrary;Integrated Security=true;Connect Timeout=15;");
            return new ParticipantLibraryContext(optionsBuilder.Options);
        }
    }
}
