 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly MovieAppContext _context;

        public CustomersController(MovieAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers.Include(c => c.MembershipType).ToListAsync();
            return View(customers);
        }

        public async Task<IActionResult> Create()
        {
            var membershipTypes = await _context.MembershipTypes.ToListAsync();
            ViewData["MembershipTypes"] = new SelectList(membershipTypes, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            CustomerValidator(customer);
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        private void CustomerValidator(Customer customer)
        {
            if (customer != null)
            {
                if (string.IsNullOrEmpty(customer.Name) || customer.Name.Length > 60)
                    ModelState.AddModelError("Name", "The name must be not null and at most 60 characters!");
                if (customer.MembershipTypeId == 0)
                    ModelState.AddModelError("MembershipType", "A membership type must be selected!");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _context.Customers.Include(c => c.MembershipType).FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            var membershipTypes = await _context.MembershipTypes.ToListAsync();
            ViewData["MembershipTypes"] = new SelectList(membershipTypes, "Id", "Name");
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            CustomerValidator(customer);
            if (ModelState.IsValid)
            {
                _context.Update(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.Include(c => c.MembershipType).FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound(); 
            }
            var membershipTypes = await _context.MembershipTypes.ToListAsync();
            ViewData["MembershipTypes"] = new SelectList(membershipTypes, "Id", "Name");
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Customer customer)
        {
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _context.Customers.Include(c => c.MembershipType).FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            var membershipTypes = await _context.MembershipTypes.ToListAsync();
            ViewData["MembershipTypes"] = new SelectList(membershipTypes, "Id", "Name");
            return View(customer);
        }

        public async Task<IActionResult> Movies(int id)
        {
            var movies = await _context.CustomerMovies
                .Where(cm => cm.CustomerId == id)
                .Select(cm => cm.Movie)
                .ToListAsync();
            return View(movies);
        }
    }
}
