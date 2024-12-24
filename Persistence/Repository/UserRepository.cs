using Application.DTOs;
using Application.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository 
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public User? GetOneByEmailAndPassword(string email, string password)
        {
            return _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> RegisterUserAsync(UserDTO userDto)
        {
            var existingUser = await GetByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                return false;
            }

            var user = new User
            {
                Name = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,
                Phone = userDto.Phone,
                Address = userDto.Address,
                RoleId = userDto.RoleId
            };

            await AddAsync(user);
            return true;
        }
    }
}
