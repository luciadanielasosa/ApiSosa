using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiSosa.Models
{
    public enum Place
    {   Salar_de_Uyuni=10,
        Camino_a_los_Yungas=20,
        Lago_Titicaca=30,
        Copacabana=40,
        Laguna_Colorada=50

    }
    public class Sosa
    {
        [Key]
        public int SosaID { get; set; }

        [Required]
        [Display(Name ="Nombre Completo")]
        [StringLength(24,ErrorMessage ="The field {0} must contain betwen {2} and {1} characters", MinimumLength =2)]
        public string FrienofSosa { get; set;}

        [Required]
        public Place Category { get; set; }


        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Cumpleaños")]
        [DisplayFormat(DataFormatString ="{0:dd//MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime Birthdate { get; set; }

    }
}