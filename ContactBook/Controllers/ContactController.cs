using ContactBook.Interfaces;
using ContactBook.Models;
using ContactBook.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace ContactBook.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet("list")]
        public IActionResult ListContacts()
        {
            IndexViewModel vm = new IndexViewModel()
            {
                Contacts = contactService.ListContacts()
            };
            return View("Contacts", vm);
        }

        [HttpGet("new")]
        public IActionResult ViewNewContactForm()
        {
            return View("NewContact");
        }

        [HttpPost("new")]
        public IActionResult NewContactForm(Contact input)
        {
            contactService.AddContact(input);
            return RedirectToAction("ListContacts");
        }

        [HttpPost("delete")]
        public IActionResult DeleteContact(Contact input)
        {
            contactService.DeleteContact(input);
            return RedirectToAction("ListContacts");
        }
        
    }
}
