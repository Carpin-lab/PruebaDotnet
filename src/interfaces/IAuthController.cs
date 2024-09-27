using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDotnet.src.Auth.dto;

namespace PruebaDotnet.src.interfaces
{
    public interface IAuthController
    {
        public Task<IActionResult> SignIn(AuthDto Credencials);

    }
}