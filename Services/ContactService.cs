using Cafe.Data;
using Cafe.Models;

namespace Cafe.Services
{
    public class ContactService : IContactService
    {
        ApplicationDbContext _db;

        public ContactService(ApplicationDbContext context)
        {
            _db = context;
        }

        public ContactForm AddContactForm(ContactForm contactForm)
        {
            if (contactForm != null)
            {
                contactForm.TimeStamp=DateTime.Now;
                contactForm.ReadStatus = false;
                _db.ContactForms.Add(contactForm);
                _db.SaveChanges();
            }
           
            return contactForm;
        }

        public ContactForm GetContactForm(int Id)
        {
            ContactForm contactForm = _db.ContactForms.Find(Id);
            if (contactForm != null) { 
                contactForm.ReadStatus = true; 
                _db.ContactForms.Update(contactForm);
                _db.SaveChanges();
            }

            return contactForm;
        }

        public IList<ContactForm> AllContactForms(int Id)
        {
            return _db.ContactForms.OrderByDescending(c=>c.TimeStamp).Skip(10*(Id-1)).Take(10).ToList();
        }

        public int ContactFormsCount()
        {
            return _db.ContactForms.Count();
        }

        public ContactForm UpdateContactForm(ContactForm contactForm)
        {
            ContactForm UpdateContact = _db.ContactForms.Find(contactForm.Id);
            if (UpdateContact != null)
            {
                UpdateContact.Name = contactForm.Name;
                UpdateContact.Phone = contactForm.Phone;
                UpdateContact.Email = contactForm.Email;
                UpdateContact.Comment = contactForm.Comment;

                _db.Update(UpdateContact);
                _db.SaveChanges();
            }
            else
            {
                return null;
            }
            return contactForm;
        }

        public bool DeleteContactForm(int Id)
        {
            ContactForm DeleteContact =_db.ContactForms.Find(Id);
            
            if (DeleteContact != null)
            {
                _db.Remove(DeleteContact);
                _db.SaveChanges();
                return true;
            } 
            return false;
        }

    }
}
