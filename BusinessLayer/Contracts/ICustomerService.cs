using BusinessLayer.Models.Customer.Input;
using BusinessLayer.Models.Customer.Output;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface ICustomerService
    {
        Task<string> CreateCustomerAsync(CreateCustomerInputBL input);
        Task<GetCustomersOutputBL> GetCustomerByUsernameAsync(string username);
        Task EditCustomer(EditCustomerInputBL input);
        Task DeleteCustomer(string username);
    }
}
