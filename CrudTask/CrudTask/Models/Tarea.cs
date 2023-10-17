using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask.Models
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Task es obligatorio")]
        public string Task { get; set; }
        public bool Status { get; set; }

       // public int IdUsuario { get; set; } // La clave foránea

        // Propiedad de navegación para acceder al usuario relacionado
        //public virtual Usuario Usuario { get; set; }

    }
}
