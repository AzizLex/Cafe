using Cafe.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Cafe.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Administrator")]
    public class UsersModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public UsersModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public List<ApplicationUser> Users { get; set; }
        public List<bool> RoleAdmin { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            public string UserName { get; set; }

        }
        private async Task LoadAsync(ApplicationUser user)
        {
            var cUser = await _userManager.GetUserAsync(User);
            Users = _userManager.Users.Where(u => u.Id != cUser.Id).ToList();

            RoleAdmin = new List<bool>();
            foreach (var ur in Users) RoleAdmin.Add(await _userManager.IsInRoleAsync(ur, "Administrator"));

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostPromoteUserAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            var userU = _userManager.Users.Where(u => u.UserName == Input.UserName).FirstOrDefault();
            if (userU != null)
            {
                if (await _userManager.IsInRoleAsync(userU, "Administrator"))
                {
                    await _userManager.RemoveFromRoleAsync(userU, "Administrator");
                }
                else
                {
                    await _userManager.AddToRoleAsync(userU, "Administrator");
                }
            }


            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteUserAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            var userU = _userManager.Users.Where(u => u.UserName == Input.UserName).FirstOrDefault();
            if (userU != null)
            {
                await _userManager.DeleteAsync(userU);
            }

            await LoadAsync(user);
            return Page();
        }
    }
}
