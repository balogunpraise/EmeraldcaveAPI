using System;

namespace Emeraldcave.Domain.Common
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        public BaseEntity()
        {
            Id = new Guid().ToString();
        }
    }
}
