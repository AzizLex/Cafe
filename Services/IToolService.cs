namespace Cafe.Services
{
    public interface IToolService
    {
        Task<bool> UploadFile(IFormFile file, string path);
    }
}
