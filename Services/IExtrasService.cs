using Cafe.Models;

namespace Cafe.Services
{
    public interface IExtrasService
    {
        bool AddExtraService(ExtraService service);
        bool RemoveExtraService(int Id);
        bool UpdateExtraService(ExtraService service);
        ExtraService GetExtraService(int Id);
        IList<ExtraService> GetAll();
    }
}
