using AutoMapper;
using BusinessLayer.Models.Customer.Input;
using BusinessLayer.Models.Customer.Output;
using Task.Models.ApiModels.Customer.Input;
using Task.Models.ApiModels.Customer.Output;

namespace Task.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<ApiCreateCustomerInput, CreateCustomerInputBL>();
            CreateMap<GetCustomersOutputBL, ApiGetCustomerByUsernameOutput>();
            CreateMap<ApiEditCustomerInput, EditCustomerInputBL>();
        }
    }
}
