using Cafe.Models;
using Cafe.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public IActionResult Index()
        {
            IList<MenuCategory> menuCategories = _menuService.GetAll();
            return View(menuCategories);
        }

    }
}
