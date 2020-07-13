namespace ITQJ.WebPWA.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Register
    {

        [Required(ErrorMessage = "El {0} es requerido.")]
        [MaxLength(25, ErrorMessage = "El {0} soporta un maximo de {1} caracteres")]
        [MinLength(8, ErrorMessage = "El {0} soporta un Minimo de {1} caracteres")]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La {0} es requerido.")]
        [DataType(DataType.Password)]
        [MaxLength(25, ErrorMessage = "El {0} soporta un maximo de {1} caracteres")]
        [MinLength(8, ErrorMessage = "El {0} soporta un Minimo de {1} caracteres")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El {0} es requerido.")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50, ErrorMessage = "El {0} soporta un maximo de {1} caracteres")]
        [MinLength(15, ErrorMessage = "El {0} soporta un Minimo de {1} caracteres")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [ForeignKey(nameof(Rol))]
        public int RolId { get; set; }

        [Required(ErrorMessage = "El {0} es requerido.")]
        [Display(Name = "Rol")]
        public virtual Rol Rol { get; set; }

    }
}
