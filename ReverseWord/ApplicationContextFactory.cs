using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using ReversedWord.Repository;

namespace ReversedWord
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Server=BREZQ;Database=ReversDb;Trusted_Connection=True;TrustServerCertificate=True", b => b.MigrationsAssembly("ReversedWord.Repository"));

            return new ApplicationContext(optionsBuilder.Options);
        }
    }

}
