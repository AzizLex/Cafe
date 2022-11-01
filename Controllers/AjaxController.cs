using Cafe.Models;
using Cafe.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Cafe.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AjaxController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IAboutService _aboutService;
        private readonly IVenueService _venueService;
        private readonly IMenuService _menuService;
        private readonly IGalleryService _galleryService;


        public AjaxController(
            IWebHostEnvironment env,
            IMenuService menuService,
            IVenueService venueService,
            IAboutService aboutService,
            IGalleryService galleryService
            )
        {
            _env = env;
            _menuService = menuService;
            _venueService = venueService;
            _aboutService = aboutService;
            _galleryService = galleryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public class AjaxFiles
        {
            public int CurrentP { get; set; }
            public int TotalP { get; set; }
            public string Folder { get; set; }
            public List<string> Folders { get; set; }
            public List<string> Files { get; set; }
        }

        [HttpPost]
        public JsonResult GetImageList([FromBody] AjaxFiles jsonInput)
        {
            AjaxFiles result = new AjaxFiles();
            char[] a = Path.GetInvalidFileNameChars();
            result.CurrentP = jsonInput.CurrentP;

            result.Folder = jsonInput.Folder is null ? "" : string.Concat(jsonInput.Folder.Split(Path.GetInvalidFileNameChars()));

            string path = HttpContext.Session.GetString("path") + "";
            List<string> folders = new List<string>();
            if (path != "") folders.AddRange(path.Split('/').ToList());
            if (result.Folder == ".." && folders.Any())
            {
                folders.RemoveAt(folders.Count - 1);
            }
            else if (result.Folder != ".." && result.Folder != "")
            {
                folders.Add(result.Folder);
            }

            path = folders.Any() ? "image/" + string.Join('/', folders) + "/" : "image/";
            string fullPath = Path.Combine(_env.WebRootPath, path);

            if (Directory.Exists(fullPath))
            {
                Regex rgx = new Regex(@"bmp|png|jpg|gif|jpeg");
                result.Folders = Directory
                    .GetDirectories(Path.GetFullPath(fullPath))
                    .Where(d => !d.EndsWith("Thumb"))
                    .Select(d => new DirectoryInfo(d).Name)
                    .ToList();

                if (folders.Any())
                {
                    result.Folders.Insert(0, "..");
                }
                var dir = new DirectoryInfo(Path.GetFullPath(fullPath));
                string[] files = dir
                    .GetFiles()
                    .Where(f => rgx.IsMatch(f.Extension) && f.Name != "placeholder.png")
                    .OrderByDescending(f => f.CreationTime)
                    .Select(f => "/" + path + f.Name)
                    .ToArray();
                result.TotalP = (int)Math.Ceiling(files.Count() / 8f);
                if (result.CurrentP < 1) { result.CurrentP = 1; }
                if (result.CurrentP > result.TotalP) { result.CurrentP = result.TotalP; }
                result.Files = files.Skip(8 * (result.CurrentP - 1)).Take(8).ToList();

            }
            HttpContext.Session.SetString("path", string.Join('/', folders));

            return Json(result);
        }

        [HttpPost]
        public IActionResult UploadFiles()
        {
            string path = Path.Combine("image" , HttpContext.Session.GetString("path"));
            string fullPath = Path.Combine(_env.WebRootPath, path);

            long size = 0;
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                filename = Path.Combine(fullPath,filename);
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            string message = $"{files.Count} file(s) / {size} bytes uploaded successfully!";
            return Json(message);
        }

        public class HFile
        {
            public string Name { get; set; }
        }

        [HttpPost]
        public IActionResult DeleteFile([FromBody] HFile file)
        {
            string fullUrl = Path.Combine("image", file.Name.Remove(0, 7));
            string fullName = Path.Combine(_env.WebRootPath,fullUrl);
            string message = "";
            if (System.IO.File.Exists(fullName))
            {
                System.IO.File.Delete(fullName);
                fullUrl = "/"+fullUrl.Replace("\\", "/");
                _aboutService.RemoveUrl(fullUrl);
                _menuService.RemoveUrl(fullUrl);
                _venueService.RemoveUrl(fullUrl);
                _galleryService.RemoveUrl(fullUrl);

                message = "success";
            }

            return Json(message);
        }

        public class MItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string URL { get; set; }
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetMenuItem([FromBody] MItem item) //Get Menu Item
        {
            MenuItem menuItem = _menuService.GetMenuItem(item.Id);
            
            item.Name = menuItem.Name;
            item.Description = menuItem.Description;
            item.URL = menuItem.URL;
           
            return Json(item);
        }

        [HttpPost]
        public IActionResult UpdateSubCatImage([FromBody] MenuSubCat item) //Get Menu Item
        {
            string message = "nochange";
            if (_menuService.UpdateMenuSubCatURL(item))
            {
                message = "success";
            }

            return Json(message);
        }
    }
}
