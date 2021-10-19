using BusinessLayer.Contracts;
using BusinessLayer.Models.Customer.Input;
using BusinessLayer.Models.Customer.Output;
using Common;
using Common.Models.Exception;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(ICacheRepository cacheRepository) : base(cacheRepository) { }

        public async Task<string> CreateCustomerAsync(CreateCustomerInputBL input)
        {
            var customerCached = await cacheRepository.GetCacheAsync<Customer>(input.Username);
            if (customerCached != null)
                throw new FailedException(Common.Constants.ErrorCodes.CustomerAlreadyExists);

            customerCached = new Customer
            {
                Username = input.Username,
                FirstName = input.FirstName,
                LastName = input.LastName
            };

            var inserted = await cacheRepository.SetAsync(customerCached.Username, customerCached);
            if (inserted)
                return input.Username;
            else
                throw new FailedException(Constants.ErrorCodes.NotInserted);
        }

        public async Task<GetCustomersOutputBL> GetCustomerByUsernameAsync(string username)
        {
            var customer = await cacheRepository.GetCacheAsync<Customer>(username);
            if (customer == null)
                throw new FailedException(Constants.ErrorCodes.NotFound);

            return new GetCustomersOutputBL { FirstName = customer.FirstName, LastName = customer.LastName, Username = customer.Username };
        }

        public async Task EditCustomer(EditCustomerInputBL input)
        {
            var customer = await cacheRepository.GetCacheAsync<Customer>(input.Username);
            if (customer == null)
                throw new FailedException(Constants.ErrorCodes.NotFound);

            await cacheRepository.DeleteAsync(customer.Username);

            customer.FirstName = input.FirstName;
            customer.LastName = input.LastName;
            await cacheRepository.SetAsync(customer.Username, customer);

        }
        public async Task DeleteCustomer(string username)
        {
            var deleted = await cacheRepository.DeleteAsync(username);
            if (deleted == false)
                throw new FailedException(Constants.ErrorCodes.NotFound);

        }


    }
}
