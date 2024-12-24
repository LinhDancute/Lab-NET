using Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IBookRepository Books{ get; }
        ICategoryRepository Categories { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        Task<int> CommitAsync();
        public void Dispose();
    }
}
