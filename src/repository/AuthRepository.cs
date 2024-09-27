using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaDotnet.src.Auth.dto;
using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.user.entity;

namespace PruebaDotnet.src.repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BdPruebaContext _context;

        public AuthRepository(BdPruebaContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> FindUser(AuthDto Credencials)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.username == Credencials.username && u.password == Credencials.password);
            return user;
        }
    }
}