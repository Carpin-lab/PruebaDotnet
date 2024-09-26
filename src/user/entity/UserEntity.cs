using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDotnet.src.user.entity
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column]
        [Required]
        [MaxLength(50)]
        public string username { get; set; }

        [Column]
        [Required]
        [MaxLength(50)]
        public string password { get; set; }

        [Column]
        [DefaultValue(1)] //Don´t work :(
        public bool state { get; set; }


    }
}