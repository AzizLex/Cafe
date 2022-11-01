
using System.ComponentModel.DataAnnotations;

namespace Cafe.Models
{
    public class MenuCategory
    {
        public int Id { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public virtual IList<MenuSubCat> SubCats { get; set; }

        public MenuCategory()
        {

        }
    }
}
