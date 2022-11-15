using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<EFContext>

{
    public EFContext CreateDbContext(string[] args)
    {
        return new EFContext();
    }
}