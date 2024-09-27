using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PruebaDotnet.src.task.entity;

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
        // [Index(IsUnique = true)] //Don´t work :(
        public string username { get; set; }

        [Column]
        [Required]
        [MaxLength(50)]
        public string password { get; set; }

        [Column]
        [DefaultValue(1)] //Don´t work :(
        public bool state { get; set; }


        public virtual ICollection<TaskEntity> tasks { get; set; }

    }
}