namespace Cafe.Services
{
    public class ToolService:IToolService
    {
        private readonly IWebHostEnvironment _env;
        public ToolService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<bool> UploadFile(IFormFile file, string path)
        {
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(_env.WebRootPath, path));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}
