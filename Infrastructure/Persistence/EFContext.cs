using System.Reflection;
using Domain.Entities.Departments;
using Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence;

public class EFContext :DbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public EFContext() : base(CreateOptions(""))
    {
    }

    public EFContext(DbContextOptions<EFContext> options,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options ?? CreateOptions(""))
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    private static DbContextOptions<EFContext> CreateOptions(string connName)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
        if (string.IsNullOrWhiteSpace(connName))
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().Build();
            connName = configuration.GetSection("ConnectionStrings:RookiesConnectionString").ToString();
        }

        optionsBuilder.UseSqlServer(connName);

        return optionsBuilder.Options;
    }

    public EFContext(string connName) : base(CreateOptions(connName))
    {
    }

    public virtual DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}