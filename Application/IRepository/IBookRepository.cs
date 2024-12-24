using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<ICollection<Book>> GetAll();
        Task<Book?> Get(int bookId);
        Task<ICollection<Book>> SearchName(string name);
    }
}
