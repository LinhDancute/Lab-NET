using Application.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;

namespace Persistence.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _dbContext;
        public BookRepository(AppDbContext context) : base(context) {
            _dbContext = context;
        }
        public async Task<Book?> Get(int bookId)
        {
            return await _dbContext.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == bookId);
        }
        public async Task<ICollection<Book>> GetAll()
        {
            return await _dbContext.Books
                .Include(b => b.Category)
                .ToListAsync();
        }
        public async Task<ICollection<Book>> SearchName(string name)
        {
            return await _dbContext.Books
                .Where(b => b.Title.Contains(name))
                .Include(b => b.Category)
                .ToListAsync();
        }
    }
}
