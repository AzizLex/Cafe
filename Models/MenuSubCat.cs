using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Models
{
    public class MenuSubCat
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "CategoryId")]
        public int MenuCategoryId { get; set; }

        [Display(Name = "URL")]
        public string URL { get; set; }

        [StringLength(256)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public virtual IList<MenuItem> Items { get; set; }

        public virtual MenuCategory Category { get; set; }

        public MenuSubCat()
        {

        }

    }
}
