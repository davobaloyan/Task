using System.ComponentModel.DataAnnotations;

namespace Task.Models.ApiModels.Customer.Input
{
    public class ApiDeleteCustomerInput
    {
        [Required]
        [MaxLength(255)]
        public string Username { get; set; }
    }
}
