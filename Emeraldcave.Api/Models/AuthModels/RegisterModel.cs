using Emeraldcave.Application.Dtos;
using Emeraldcave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emeraldcave.Api.Models.AuthModels
{
    public class RegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AltPhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
    }
}
