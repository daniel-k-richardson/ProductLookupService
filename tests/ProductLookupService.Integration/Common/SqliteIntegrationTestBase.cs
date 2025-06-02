using Microsoft.EntityFrameworkCore;
using ProductLookupService.Persistence.Data;

namespace ProductLookupService.Integration.Common
{
    public abstract class SqliteIntegrationTestBase : IDisposable
    {
        protected readonly AppDataContext Context;

        protected SqliteIntegrationTestBase()
        {
            DbContextOptions<AppDataContext> options = new DbContextOptionsBuilder<AppDataContext>()
                .UseSqlite($"DataSource=file:memdb{Guid.NewGuid()}?mode=memory&cache=shared")
                .Options;
            Context = new AppDataContext(options);
            Context.Database.OpenConnection();
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
