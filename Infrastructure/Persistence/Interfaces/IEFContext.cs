namespace Infrastructure.Persistence.Interfaces;

public interface IEFContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}