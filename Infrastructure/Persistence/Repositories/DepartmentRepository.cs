using Domain.Entities.Departments;

namespace Infrastructure.Persistence.Repositories;

public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
{
    public DepartmentRepository(EFContext dbContext) : base(dbContext)
    {
    }
}