using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReservaSalaReuniones.En.ModelView.Usuario
{
    public class LoginModelView
    {
        [Required]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string NickName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
