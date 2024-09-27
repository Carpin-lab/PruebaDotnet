using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDotnet.src.Auth.dto;
using PruebaDotnet.src.user.entity;

namespace PruebaDotnet.src.interfaces
{
    public interface IAuthServices
    {
        public Task<UserEntity> FindUser(AuthDto Credencials);
        public JwtDto SignTokens(UserEntity Credencials);
    }
}