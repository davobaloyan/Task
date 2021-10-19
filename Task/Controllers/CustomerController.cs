using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models.Customer.Input;
using BusinessLayer.Models.Customer.Output;
using Common;
using Common.Models.Exception;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models.ApiModels;
using Task.Models.ApiModels.Customer.Input;
using Task.Models.ApiModels.Customer.Output;

namespace Task.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ApiResponseModel<string>> CreateCustomer(ApiCreateCustomerInput customerInput)
        {
            if (!ModelState.IsValid)
                throw new FailedException(Constants.ErrorCodes.InvalidInput);

            var inputBL = mapper.Map<ApiCreateCustomerInput, CreateCustomerInputBL>(customerInput);
            var username = await customerService.CreateCustomerAsync(inputBL);
            return new ApiResponseModel<string> { ResponseCode = (int)Constants.ErrorCodes.Success, ResponseModel = username };
        }

        [HttpGet]
        public async Task<ApiResponseModel<ApiGetCustomerByUsernameOutput>> GetCustomerByUsername(string username)
        {
            var customer = await customerService.GetCustomerByUsernameAsync(username);
            var output = mapper.Map<GetCustomersOutputBL, ApiGetCustomerByUsernameOutput>(customer);
            return new ApiResponseModel<ApiGetCustomerByUsernameOutput> { ResponseCode = (int)Constants.ErrorCodes.Success, ResponseModel = output };
        }

        [HttpPut]
        public async Task<ApiResponseModel<object>> EditCustomer(ApiEditCustomerInput input)
        {
            var inputBL = mapper.Map<ApiEditCustomerInput, EditCustomerInputBL>(input);
            await customerService.EditCustomer(inputBL);

            return new ApiResponseModel<object> { ResponseCode = (int)Constants.ErrorCodes.Edited, ResponseModel = null };
        }

        [HttpDelete]
        public async Task<ApiResponseModel<object>> DeleteCustomer(ApiDeleteCustomerInput input)
        {
            if (!ModelState.IsValid)
                return new ApiResponseModel<object> { ResponseCode = (int)Constants.ErrorCodes.InvalidInput };

            await customerService.DeleteCustomer(input.Username);
            return new ApiResponseModel<object> { ResponseCode = (int)Constants.ErrorCodes.Deleted, ResponseModel = null };
        }







    }
}
