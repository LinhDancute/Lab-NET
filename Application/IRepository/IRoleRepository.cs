using Domain.Entities;

namespace Application.IRepository
{
    public interface IRoleRepository
    {
        Task<ICollection<Role>> GetAll();
        Task<Role?> GetByNameAsync(string roleName);
    }
}
