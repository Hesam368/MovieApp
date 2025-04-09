 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using MovieApp.Repositories;

namespace MovieApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return View(customers);
        }

        public async Task<IActionResult> Create()
        {
            var membershipTypes = await _customerRepository.GetMembershipTypes();
            ViewData["MembershipTypes"] = new SelectList(membershipTypes, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            CustomerValidator(customer);
            if (ModelState.IsValid)
            {
                await _customerRepository.UpdateCustomer(customer);
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
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var membershipTypes = await _customerRepository.GetMembershipTypes();
            ViewData["MembershipTypes"] = new SelectList(membershipTypes, "Id", "Name");
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            CustomerValidator(customer);
            if (ModelState.IsValid)
            {
                await _customerRepository.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound(); 
            }
            var membershipTypes = await _customerRepository.GetMembershipTypes();
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
            await _customerRepository.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var membershipTypes = await _customerRepository.GetMembershipTypes();
            ViewData["MembershipTypes"] = new SelectList(membershipTypes, "Id", "Name");
            return View(customer);
        }
    }
}
