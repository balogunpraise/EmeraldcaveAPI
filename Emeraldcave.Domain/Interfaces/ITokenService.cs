using Emeraldcave.Domain.Entities;

namespace Emeraldcave.Domain.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
