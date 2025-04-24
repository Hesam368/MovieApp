using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MovieAppContext _context;

        public CustomerRepository(MovieAppContext context)
        {
            _context = context;
        }
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> DeleteCustomerAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.Include(c => c.MembershipType).ToListAsync();
        }

        public async Task<IEnumerable<MembershipType>> GetMembershipTypesAsync()
        {
            return await _context.MembershipTypes.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customers.Include(c => c.MembershipType).FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task<Customer?> UpdateCustomerAsync(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
