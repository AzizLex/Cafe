using Cafe.Models;

namespace Cafe.Services
{
    public interface IAboutService
    {
        About ReadAbout();
        bool UpdateAbout(About about);
        bool RemoveUrl(string url);

        Policy ReadPolicy();
        bool UpdatePolicy(Policy policy);

        List<Option> ReadOption(string key);
        List<Option> ReadOptions();
        bool UpdateOptions(IList<Option> options);
        bool DeleteOption(int id);
    }
}
