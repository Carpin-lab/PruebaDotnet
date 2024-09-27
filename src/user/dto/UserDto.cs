using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PruebaDotnet.src.user.entity;

namespace PruebaDotnet.src.user.dto
{
    public class UserDto
    {


        public int? id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}