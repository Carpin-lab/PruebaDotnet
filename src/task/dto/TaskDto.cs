using System.ComponentModel.DataAnnotations;

namespace PruebaDotnet.src.task.dto
{
    public class TaskDto
    {

        public int? id { get; set; }
        [Required(ErrorMessage = "El título es obligatorio.")]
        public string title { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string description { get; set; }

        [Required(ErrorMessage = "La fecha de expiración es obligatoria.")]
        public DateTime expiration_date { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool state { get; set; }

        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        public int user_id { get; set; }

    }
}