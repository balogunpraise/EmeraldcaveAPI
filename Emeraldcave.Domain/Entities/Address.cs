using Emeraldcave.Domain.Common;

namespace Emeraldcave.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string State { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}