using System.ComponentModel.DataAnnotations;

namespace Cafe.Models
{
    public class MenuItem
    {

        public int Id { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }



        [Required]
        [Display(Name = "SubCatId")]
        public int MenuSubCatId { get; set; }


        [Display(Name = "Price")]
        public double? Price { get; set; }

        public string URL { get; set; }

        public virtual MenuSubCat SubCat { get; set; }

        public MenuItem()
        {

        }   
    }
}
