using Cafe.Data;
using Cafe.Models;

namespace Cafe.Services
{
    public class MenuService : IMenuService
    {
        ApplicationDbContext _db;
        public MenuService(ApplicationDbContext context)
        {
            _db = context;
        }


        //CRUD
        //Create - Add
        //Read - Get
        //Update - Update
        //Delete - Remove
        //MenuCategory → MenuImage → MenuItem
        //!!Changed. Removed MenuImage. Repplaced/changed to MenuSubCat

        //Create - Add
        public Boolean AddMenuCategory(MenuCategory menuCategory)
        {
            if (menuCategory != null)
            {
                _db.MenuCategories.Add(menuCategory);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        public Boolean AddMenuSubCat(MenuSubCat menuSubCat)
        {
            if (menuSubCat != null)
            {
                _db.MenuSubCats.Add(menuSubCat);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        public Boolean AddMenuItem(MenuItem menuItem)
        {
            if (menuItem != null)
            {
                _db.MenuItems.Add(menuItem);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }


        //Read - Get
        public MenuCategory GetMenuCategory(int id)
        {
            MenuCategory menuCategory = _db.MenuCategories.Find(id);

            return menuCategory;
        }
        public MenuSubCat GetMenuSubCat(int id)
        {
            MenuSubCat menuSubCat = _db.MenuSubCats.Find(id);

            return menuSubCat;
        }
        public MenuItem GetMenuItem(int id)
        {
            MenuItem menuItem = _db.MenuItems.Find(id);

            return menuItem;
        }



        //Update - Update
        public Boolean UpdateMenuCategory(MenuCategory menuCategory)
        {
            MenuCategory menuCategoryU = _db.MenuCategories.Find(menuCategory.Id);
            if (menuCategoryU != null)
            {
                if (menuCategoryU.Name != menuCategory.Name) menuCategoryU.Name = menuCategory.Name;

                if (menuCategory.SubCats == null)
                {
                    menuCategory.SubCats = new List<MenuSubCat>();
                }
                var subCatsToRemove = menuCategoryU.SubCats.Where(s => !menuCategory.SubCats.Any(m => s.Id == m.Id));
                _db.MenuSubCats.RemoveRange(subCatsToRemove);



                if (menuCategory.SubCats != null)
                {
                    MenuSubCat subCatU;

                    foreach (var subCat in menuCategory.SubCats)
                    {
                        if (subCat.Id == 0)
                        {
                            subCatU = new MenuSubCat();
                            subCatU.Name = subCat.Name;
                            menuCategoryU.SubCats.Add(subCatU);
                        }
                        else
                        {
                            subCatU = menuCategoryU.SubCats.FirstOrDefault(s => s.Id == subCat.Id);
                            if (subCatU != null)
                            {
                                if (subCatU.Name != subCat.Name) subCatU.Name = subCat.Name;
                            }
                        }

                    }
                }

                _db.Update(menuCategoryU);
                _db.SaveChanges();
            }
            else
            {
                menuCategoryU = new MenuCategory();
                menuCategoryU.SubCats = new List<MenuSubCat>();
                menuCategoryU.Name = menuCategory.Name;
                if (menuCategory.SubCats != null)
                {
                    foreach (var subCat in menuCategory.SubCats)
                    {
                        var subCatU = new MenuSubCat();
                        subCatU.Name = subCat.Name;
                        menuCategoryU.SubCats.Add(subCatU);
                    }
                }
                _db.MenuCategories.Add(menuCategoryU);
                _db.SaveChanges();
            }
            return true;
        }
        public Boolean UpdateMenuSubCat(MenuSubCat menuSubCat)
        {
            MenuSubCat menuSubCatU = _db.MenuSubCats.Find(menuSubCat.Id);
            if (menuSubCatU != null)
            {
                menuSubCatU.Name = menuSubCat.Name;

                menuSubCatU.URL = menuSubCat.URL;
                menuSubCatU.MenuCategoryId = menuSubCat.MenuCategoryId;

                _db.Update(menuSubCat);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;

        }
        public Boolean UpdateMenuSubCatURL(MenuSubCat menuSubCat)
        {
            MenuSubCat menuSubCatU = _db.MenuSubCats.Find(menuSubCat.Id);
            if (menuSubCatU != null)
            {
                if (menuSubCatU.URL != menuSubCat.URL)
                {
                    menuSubCatU.URL = menuSubCat.URL;
                    _db.Update(menuSubCatU);
                    _db.SaveChanges();
                }
            }
            else { return false; }
            return true;
        }
        public bool UpdateMenuItem(MenuItem menuItem)
        {
            MenuItem menuItemU = _db.MenuItems.Find(menuItem.Id);
            if (menuItemU is null) { menuItemU = new MenuItem(); }
            menuItemU.Name = menuItem.Name;
            menuItemU.URL = menuItem.URL;
            menuItemU.Description = menuItem.Description;
            menuItemU.Price = menuItem.Price;
            menuItemU.MenuSubCatId = menuItem.MenuSubCatId;

            if (menuItemU.Id != 0)
            {
                _db.Update(menuItemU);
            }
            else { _db.MenuItems.Add(menuItemU); }
            _db.SaveChanges();

            return true;
        }


        //Delete - Remove
        public Boolean RemoveMenuCategory(int Id)
        {
            MenuCategory menuCategory = _db.MenuCategories.Find(Id);

            if (menuCategory != null)
            {
                _db.MenuCategories.Remove(menuCategory);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        public Boolean RemoveMenuSubCat(int Id)
        {
            MenuSubCat menuSubCat = _db.MenuSubCats.Find(Id);

            if (menuSubCat != null)
            {
                _db.MenuSubCats.Remove(menuSubCat);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        public Boolean RemoveMenuItem(int Id)
        {
            MenuItem menuItem = _db.MenuItems.Find(Id);

            if (menuItem != null)
            {
                _db.MenuItems.Remove(menuItem);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public IList<MenuSubCat> GetMenuSubCats(int menuCategoryId)
        {
            IList<MenuSubCat> subCatList = _db.MenuCategories.Find(menuCategoryId).SubCats.ToList();

            return subCatList;

        }

        public IList<MenuCategory> GetAll()
        {
            //throw new NotImplementedException();


            IList<MenuCategory> menuCategories = _db.MenuCategories.ToList();
            return menuCategories;

        }
        public bool RemoveUrl(string url)
        {
            List<MenuSubCat> subCats = _db.MenuSubCats
                .Where(msc => msc.URL == url).ToList();
            foreach (var subCat in subCats)
            {
                subCat.URL = "/image/menu/placeholder.png";
            }
            _db.UpdateRange(subCats);
            _db.SaveChanges();

            List<MenuItem> menuItems=_db.MenuItems
                .Where(mi=>mi.URL==url).ToList();
            foreach (var item in menuItems)
            {
                item.URL = "/image/menu/placeholder.png";
            }
            _db.UpdateRange(menuItems);
            
            _db.SaveChanges();


            return true;
        }
    }
}
