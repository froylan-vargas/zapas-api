using Microsoft.EntityFrameworkCore;
using Zapas.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using zapas.Tests.Data.DbTestInitData;

namespace zapas.Tests.TestDB
{
    public class ApplicationTestDbContext : ApplicationDbContext
    {
        public ApplicationTestDbContext(DbContextOptions options) : base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(
                    @"server=localhost;port=3306;database=mycontext;uid=root;password=admin");
            }
        }
        public static ApplicationTestDbContext GetTestContext()
        {
            ApplicationTestDbContext context = new(CreateContextOptions());
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Zapas.AddRange(ZapaTestData.ZapaData);
            context.RaceTypes.AddRange(RaceTypeTestData.RaceTypeData);
            context.Races.AddRange(RaceTestData.RaceData);
            context.Places.AddRange(PlaceTestData.PlaceData);

            context.SaveChanges(true);
            return context;
        }

        private static DbContextOptions<ApplicationTestDbContext> CreateContextOptions()
        {
            
            return new DbContextOptionsBuilder<ApplicationTestDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                        .Options;
        }
    }
}

