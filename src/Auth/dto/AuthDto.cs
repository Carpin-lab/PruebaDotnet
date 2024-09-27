using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDotnet.src.Auth.dto
{
    public class AuthDto
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}