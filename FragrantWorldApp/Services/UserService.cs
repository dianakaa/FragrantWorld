using FragrantWorldApp.Data;
using FragrantWorldApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragrantWorldApp.Services
{
    public class UserService
    {
        private readonly FragrantWorldContext _context;

        public UserService(FragrantWorldContext context)
        {
            _context = context;
        }

        // Метод для получения всех пользователей из базы данных
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Метод для авторизации пользователя
        public async Task<User> LoginAsync(string login, string password)
        {
            return await Task.Run(() => _context.Users
            .SingleOrDefault(u => u.Login == login && u.Password == password));
        }
    }
}
