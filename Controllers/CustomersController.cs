using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Repositories;
using MovieApp.ViewModels;

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
            var customers = await _customerRepository.GetAllCustomersAsync();
            return View(customers);
        }

        public async Task<IActionResult> Create()
        {
            var model = new CustomerViewModel()
            {
                MembershipTypes = await _customerRepository.GetMembershipTypesAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = BuildCustomer(model);
                await _customerRepository.AddCustomerAsync(customer);
                return RedirectToAction("Index");
            }
            model.MembershipTypes = await _customerRepository.GetMembershipTypesAsync();
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var model = await BuildCustomerViewModel(customer);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = BuildCustomer(model);
                customer.Id = model.Id; // Ensure the ID is set for the update

                await _customerRepository.UpdateCustomerAsync(customer);
                return RedirectToAction("Index");
            }
            model.MembershipTypes = await _customerRepository.GetMembershipTypesAsync();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var model = await BuildCustomerViewModel(customer);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerRepository.DeleteCustomerAsync(customer);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var model = await BuildCustomerViewModel(customer);
            return View(model);
        }

        private async Task<CustomerViewModel> BuildCustomerViewModel(Customer customer)
        {
            return new CustomerViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter,
                Birthdate = customer.Birthdate,
                MembershipTypeId = customer.MembershipTypeId,
                MembershipTypes = await _customerRepository.GetMembershipTypesAsync()
            };
        }

        private static Customer BuildCustomer(CustomerViewModel model)
        {
            return new Customer()
            {
                Name = model.Name,
                IsSubscribedToNewsletter = model.IsSubscribedToNewsletter,
                Birthdate = model.Birthdate,
                MembershipTypeId = model.MembershipTypeId
            };
        }
    }
}
