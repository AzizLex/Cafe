namespace Cafe.Models.ViewModels
{
    public class AdminMenuVM
    {
        public IList<MenuCategory> Categories { get; set; }
        public MenuCategory newCategory { get; set; }

        public AdminMenuVM()
        {

        }
    }
}
