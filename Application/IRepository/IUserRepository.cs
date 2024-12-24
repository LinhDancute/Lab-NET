using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? GetOneByEmailAndPassword(string email, string password);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> RegisterUserAsync(UserDTO userDto);
    }
}
