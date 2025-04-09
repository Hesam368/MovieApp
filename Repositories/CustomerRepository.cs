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
        public async Task<Customer> AddCustomer(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.Include(c => c.MembershipType).ToListAsync();
        }

        public async Task<IEnumerable<MembershipType>> GetMembershipTypes()
        {
            return await _context.MembershipTypes.ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int customerId)
        {
            return await _context.Customers.Include(c => c.MembershipType).FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task<Customer?> UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
