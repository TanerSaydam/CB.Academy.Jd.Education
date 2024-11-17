using GenericRepository;
using PersonelTakip.Domain.Models;
using PersonelTakip.Domain.Repositories;
using PersonelTakip.Infrastructure.Context;

namespace PersonelTakip.Infrastructure.Repositories;
internal sealed class EmployeeRepository : Repository<Employee, ApplicationDbContext>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
