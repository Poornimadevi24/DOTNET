using MVC_Assignment.Models;
using MVC_Assignment.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_Assignment.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController()
        {
            _repository = new ContactRepository();
        }

        // GET: Contact
        public async Task<ActionResult> Index()
        {
            var data = await _repository.GetAllAsync();
            return View(data);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Edit
        public async Task<ActionResult> Edit(long id)
        {
            var data = await _repository.GetByIdAsync(id);
            return View(data);
        }

        // POST: Edit
        [HttpPost]
        public async Task<ActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Details
        public async Task<ActionResult> Details(long id)
        {
            var data = await _repository.GetByIdAsync(id);
            return View(data);
        }

        // GET: Delete
        public async Task<ActionResult> Delete(long id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}