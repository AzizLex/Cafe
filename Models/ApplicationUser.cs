using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cafe.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [PersonalData]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [PersonalData]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
