using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.HomeViewModels
{
    public class VerstuurEmailViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Uw volledige naam")]
        public string Naam { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name="Uw e-mailadres")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Het onderwerp")]
        public string Onderwerp { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Uw boodschap")]
        public string Bericht { get; set; }
    }
}
