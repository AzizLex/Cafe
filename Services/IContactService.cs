using Cafe.Models;

namespace Cafe.Services
{
    public interface IContactService

    {
        //Contact form CRUD - create, read, update, delete

        ContactForm AddContactForm(ContactForm contactForm);
        ContactForm GetContactForm(int Id);
        IList<ContactForm> AllContactForms(int Id);
        int ContactFormsCount();
        ContactForm UpdateContactForm(ContactForm contactForm);
        bool DeleteContactForm(int Id);
    }
}
