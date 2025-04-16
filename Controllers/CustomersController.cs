using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var customers = await _customerRepository.GetAllCustomers();
            return View(customers);
        }

        public async Task<IActionResult> Create()
        {
            var customerVM = new CustomerViewModel()
            {
                MembershipTypes = await _customerRepository.GetMembershipTypes()
            };
            return View(customerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel customerVM)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    Name = customerVM.Name,
                    IsSubscribedToNewsletter = customerVM.IsSubscribedToNewsletter,
                    Birthdate = customerVM.Birthdate,
                    MembershipTypeId = customerVM.MembershipTypeId
                };
                await _customerRepository.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            customerVM.MembershipTypes = await _customerRepository.GetMembershipTypes();
            return View(customerVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerVM = new CustomerViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter,
                Birthdate = customer.Birthdate,
                MembershipTypeId = customer.MembershipTypeId,
                MembershipTypes = await _customerRepository.GetMembershipTypes()
            };
            return View(customerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerViewModel customerVM)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    Id = customerVM.Id,
                    Name = customerVM.Name,
                    IsSubscribedToNewsletter = customerVM.IsSubscribedToNewsletter,
                    Birthdate = customerVM.Birthdate,
                    MembershipTypeId = customerVM.MembershipTypeId
                };
                await _customerRepository.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            customerVM.MembershipTypes = await _customerRepository.GetMembershipTypes();
            return View(customerVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerRepository.GetMembershipTypes();
            return View(customer);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
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
            await _customerRepository.GetMembershipTypes();
            return View(customer);
        }
    }
}
