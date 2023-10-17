using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Username es obligatorio")]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo Password es obligatorio")]
        public string Password { get; set; }

        //public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
