using MovieApp.Models;

namespace MovieApp.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer?> GetCustomerById(int customerId);
        Task<Customer?> UpdateCustomer(Customer customer);
        Task<Customer?> DeleteCustomer(Customer customer);
        Task<IEnumerable<MembershipType>> GetMembershipTypes();
    }
}
