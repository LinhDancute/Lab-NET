using Application.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;

namespace Persistence.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly AppDbContext _dbContext;
        public RoleRepository(AppDbContext context) : base(context) {
            _dbContext = context;
        }
        public async Task<ICollection<Role>> GetAll()
        {
            return await _dbContext.Roles
                .ToListAsync();
        }
        
        public async Task<Role?> GetByNameAsync(string roleName)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }
    }
}
