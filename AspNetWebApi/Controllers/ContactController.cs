using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetWebApi.Data;
using AspNetWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetWebApi.Controllers
{
    [Route("[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactsApiDbContext _context;

        public ContactController(ContactsApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetContacts(){
            var contacts = _context.contacts.ToList();
            if(contacts == null) return NotFound();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public ActionResult GetContact(Guid id){
            var contact = _context.contacts.Where(x => x.Id == id).FirstOrDefault();
            if(contact == null) return NotFound();
            return Ok(contact);
        }
        [HttpPost]
        public ActionResult AddContact([FromBody]AddContactRequest request){
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address
            };
            if(request == null) BadRequest();
            _context.contacts.Add(contact);
            _context.SaveChanges(); 
            return CreatedAtAction(nameof(GetContact),new {id = contact.Id},contact);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContact(Guid id){
            var contact = _context.contacts.Where(x => x.Id == id).FirstOrDefault();
            if(contact == null) return NotFound();
            _context.contacts.Remove(contact);
            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateContact(Guid id,[FromBody]UpdateContactRequest request){
            var found = _context.contacts.Find(id);
            if(found != null){
                found.FullName = request.FullName;
                found.Email = request.Email;
                found.Phone = request.Phone;
                found.Address = request.Address;
                _context.SaveChanges();
                return Ok(found);
            }
            return NotFound();

        }
    }
}