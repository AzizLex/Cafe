using Cafe.Data;
using Cafe.Models;

namespace Cafe.Services
{
    public class ExtrasService : IExtrasService
    {
        ApplicationDbContext _db;
        public ExtrasService(ApplicationDbContext context)
        {
            _db = context;
        }
        public bool AddExtraService(ExtraService service)
        {
            if (service != null)
            {
                _db.ExtraServices.Add(service);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public ExtraService GetExtraService(int Id)
        {
            ExtraService service = _db.ExtraServices.Find(Id);

            return service;
        }

        public ExtraService GetExtraServiceItem(int Id)
        {
            ExtraService service = _db.ExtraServices.Find(Id);

            return service;
        }

        public bool RemoveExtraService(int Id)
        {
            ExtraService service = _db.ExtraServices.Find(Id);

            if (service != null)
            {
                _db.ExtraServices.Remove(service);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool UpdateExtraService(ExtraService service)
        {
            ExtraService serviceU = _db.ExtraServices.Find(service.Id);
            if (serviceU != null)
            {
                serviceU.Name = service.Name;
                serviceU.Price = service.Price;

                _db.Update(serviceU);
                
            }
            else
            {
                serviceU=new ExtraService();
                serviceU.Name = service.Name;
                serviceU.Price = service.Price;

                _db.ExtraServices.Add(serviceU);
               
            }
            _db.SaveChanges();
            return true;
        }

        public IList<ExtraService> GetAll()
        {
            IList<ExtraService> extra = _db.ExtraServices.ToList();

            return extra;
        }
    }
}
