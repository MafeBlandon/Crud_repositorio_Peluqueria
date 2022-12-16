using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modelos
{
    public class Categoria
    {


        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "ingresa un nombre del cliente ")]
        [Display(Name = "nombre cliente")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Ingrese el numero de identificacion")]

        public int Identificacion { get; set; }

        [Required(ErrorMessage = "ingresa sus datos  ")]
        [Display(Name = "Datos")]

        public string Datos { get; set; }


    }
}
