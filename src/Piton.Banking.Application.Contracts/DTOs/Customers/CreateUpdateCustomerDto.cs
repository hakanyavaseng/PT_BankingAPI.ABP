using Piton.Banking.Consts.Customers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Piton.Banking.DTOs.Customers
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        [StringLength(CustomerConsts.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(CustomerConsts.LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(CustomerConsts.IdentityNumberMaxLength)]
        public string IdentityNumber { get; set; }

        [Required]
        [StringLength(CustomerConsts.BirthPlaceMaxLength)]
        public string BirthPlace { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
