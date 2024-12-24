using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;

namespace Persistence.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext context) : base(context) {
            _dbContext = context;
        }
        public async Task<Category?> Get(int categoryId)
        {
            return await _dbContext.Categories
                .FirstOrDefaultAsync(b => b.Id == categoryId);
        }
        public async Task<ICollection<Category>> GetAll()
        {
            return await _dbContext.Categories
                .ToListAsync();
        }
    }
}
