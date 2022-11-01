using Cafe.Data;
using Cafe.Models;
using Microsoft.CodeAnalysis.Options;

namespace Cafe.Services
{
    public class AboutService : IAboutService
    {
        private readonly ApplicationDbContext _db;

        public AboutService(ApplicationDbContext context)
        {
            _db = context;
        }

        public About ReadAbout()
        {
            return _db.About.FirstOrDefault();
        }

        public Boolean UpdateAbout(About about)
        {
            About aboutU = _db.About.FirstOrDefault();
            if (aboutU != null)
            {
                aboutU.Name = about.Name;
                aboutU.Description = about.Description;
                aboutU.Motto = about.Motto;
                aboutU.URL = about.URL;

                _db.About.Update(aboutU);
                _db.SaveChanges();
            }
            else
            {
                aboutU = new About();
                aboutU.Name = about.Name;
                aboutU.Description = about.Description;
                aboutU.Motto = about.Motto;
                aboutU.URL = about.URL;

                _db.About.Add(aboutU);
                _db.SaveChanges();
            }
            return true;
        }

        public Policy ReadPolicy() { return _db.Policy.FirstOrDefault(); }

        public Boolean UpdatePolicy(Policy policy)
        {
            Policy policyU = _db.Policy.FirstOrDefault();
            if (policyU != null)
            {
                policyU.Name = policy.Name;
                policyU.Lead = policy.Lead;
                policyU.Description = policy.Description;
                policyU.EditDate = DateTime.UtcNow;

                _db.Policy.Update(policyU);
                _db.SaveChanges();
            }
            else
            {
                policyU = new Policy();
                policyU.Name = policy.Name;
                policyU.Lead = policy.Lead;
                policyU.Description = policy.Description;
                policyU.EditDate = DateTime.UtcNow;

                _db.Policy.Add(policyU);
                _db.SaveChanges();
            }
            return true;
        }

        public List<Option> ReadOption(string key)
        {
            return _db.Options.Where(o => o.Key == key).ToList();
        }

        public List<Option> ReadOptions()
        {
            return _db.Options.OrderBy(o => o.Id).ToList();
        }
        public bool UpdateOptions(IList<Option> options)
        {
            foreach (Option opt in options)
            {
                Option optionU = _db.Options.Find(opt.Id);
                if (optionU != null && optionU.Value != opt.Value)
                {
                    optionU.Value = opt.Value;
                    _db.Update(optionU);

                }
            }
            _db.SaveChanges();

            return true;
        }

        public bool DeleteOption(int id)
        {
            Option optionU = _db.Options.Find(id);
            if (optionU != null)
            {
                _db.Options.Remove(optionU);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveUrl(string url)
        {
            About about = _db.About.FirstOrDefault();
            if (about != null && about.URL == url)
            {
                about.URL = "/image/placeholder.png";
                _db.Update(about);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
