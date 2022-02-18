using Emeraldcave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emeraldcave.Application.Dtos
{
    public class AddressDto
    {
        public string State { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string AppUserId { get; set; }
    }
}
