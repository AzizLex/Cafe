using Cafe.Models;

namespace Cafe.Services
{
    public interface IMenuService
    {        
        Boolean AddMenuCategory(MenuCategory menuCategory);
        MenuCategory GetMenuCategory(int Id);

        Boolean UpdateMenuCategory(MenuCategory menuCategory);
        Boolean RemoveMenuCategory(int Id);

        Boolean AddMenuSubCat(MenuSubCat menuSubCat);
        MenuSubCat GetMenuSubCat(int Id);
        Boolean UpdateMenuSubCat(MenuSubCat menuSubCat);
        Boolean RemoveMenuSubCat(int Id);
        Boolean UpdateMenuSubCatURL(MenuSubCat menuSubCat);

        Boolean AddMenuItem(MenuItem menuItem);
        MenuItem GetMenuItem(int Id);
        bool UpdateMenuItem(MenuItem menuItem);
        Boolean RemoveMenuItem(int Id);

        IList<MenuSubCat> GetMenuSubCats(int menuId);
        IList<MenuCategory> GetAll();

        bool RemoveUrl(string url); 

    }
}

