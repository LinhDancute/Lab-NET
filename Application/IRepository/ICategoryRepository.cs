using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<ICollection<Category>> GetAll();
        Task<Category?> Get(int categoryId);
    }
}
