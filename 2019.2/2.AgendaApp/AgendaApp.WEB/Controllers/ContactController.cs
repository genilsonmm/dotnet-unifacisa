using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaApp.DATA;
using AgendaApp.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.WEB.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext context;

        public ContactController(DataContext context)
        {
            this.context = context;
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View(context.Contacts);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                context.Add(contact);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(GetContact(id));
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                Contact currentContact = GetContact(id);
                currentContact.Name = contact.Name;
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(GetContact(id));
        }

        // POST: Contact/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Contact contact)
        {
            try
            {
                context.Remove(GetContact(contact.Id));
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Contact GetContact(Guid id)
        {
            return context.Contacts.Where(c => c.Id.Equals(id)).FirstOrDefault();
        }
    }
}