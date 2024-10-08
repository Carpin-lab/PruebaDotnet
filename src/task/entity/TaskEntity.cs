using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PruebaDotnet.src.user.entity;

namespace PruebaDotnet.src.task.entity
{
    public class TaskEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column]
        [Required]
        [MaxLength(50)]
        public string title { get; set; }

        [Column]
        [Required]
        [MaxLength(50)]
        public string description { get; set; }

        [Column]
        [Required]
        public DateTime expiration_date { get; set; }

        [Column]
        [Required]
        public int state { get; set; }
        /**
            * 0 = delete
            * 1 = active
            * 2 = pending
            * 3 = finished
            */


        //Foreing key
        [Column]
        [Required]
        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual UserEntity user { get; set; }
    }
}