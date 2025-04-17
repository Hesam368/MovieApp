using MovieApp.Models;

namespace MovieApp.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer?> GetCustomerByIdAsync(int customerId);
        Task<Customer?> UpdateCustomerAsync(Customer customer);
        Task<Customer?> DeleteCustomerAsync(Customer customer);
        Task<IEnumerable<MembershipType>> GetMembershipTypesAsync();
    }
}
