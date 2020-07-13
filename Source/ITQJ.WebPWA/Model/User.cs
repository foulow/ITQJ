namespace ITQJ.WebPWA.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {

        [Required(ErrorMessage = "El {0} es requerido.")]
        [MaxLength(25,ErrorMessage = "El {0} soporta un maximo de {1} caracteres")]
        [MinLength(8, ErrorMessage = "El {0} soporta un Minimo de {1} caracteres")]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La {0} es requerido.")]
        [DataType(DataType.Password)]
        [MaxLength(25, ErrorMessage = "El {0} soporta un maximo de {1} caracteres")]
        [MinLength(8, ErrorMessage = "El {0} soporta un Minimo de {1} caracteres")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }


    }
}
