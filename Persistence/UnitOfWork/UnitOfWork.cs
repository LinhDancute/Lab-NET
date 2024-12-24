using Application.IRepository;
using Application.IUnitOfWork;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        public IBookRepository Books { get; }
        public ICategoryRepository Categories { get; }
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
            Categories = new CategoryRepository(_context);
            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
        }       

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
