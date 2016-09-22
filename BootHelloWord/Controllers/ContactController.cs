using BootHelloWord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootHelloWord.Controllers
{
    public class ContactController : Controller
    {

        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Find(string firstName = "", string lastName = "")
        {
            var result = from contact in contacts
                         where (string.IsNullOrEmpty(firstName) || contact.FirstName.ToLower().Contains(firstName.ToLower()))
                             && (string.IsNullOrEmpty(lastName) || contact.LastName.ToLower().Contains(lastName.ToLower()))
                         orderby contact.Id
                         select contact;
            return View("ContactListPartial", result.ToArray());
        }


        [HttpGet]
        public ActionResult Update(string contactId)
        {
            Contact contact = contacts.First(c => c.Id == contactId);
            return View("ContactPartial", contact);
        }

        [HttpPost]
        public string Update(Contact contact)
        {
            contacts.Remove(contacts.First(c => c.Id == contact.Id));
            contacts.Add(contact);
            return "OK";
        }


        private static List<Contact> contacts = new List<Contact>
        {
            new Contact{Id = "001", FirstName = "San", LastName = "Zhang", EmailAddress = "zhangsan@gmail.com", PhoneNo="123"},
            new Contact{Id = "002", FirstName = "Si", LastName = "Li", EmailAddress = "zhangsan@gmail.com", PhoneNo="456"}
        };

    }
}