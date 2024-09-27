using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDotnet.src.user.entity;

namespace PruebaDotnet.src.user.dto
{
    public class UserDto
    {
        public int? id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}