using System.ComponentModel.DataAnnotations;

namespace Task.Models.ApiModels.Customer.Input
{
    public class ApiCreateCustomerInput
    {
        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
    }
}
