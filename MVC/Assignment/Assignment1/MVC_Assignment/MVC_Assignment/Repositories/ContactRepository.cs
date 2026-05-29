using MVC_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVC_Assignment.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private ContactDBEntities _context = new ContactDBEntities();

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(long id)
        {
            return await _context.Contacts.FindAsync(id);
        }
        public async Task CreateAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(long id)
        {
            var data = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}