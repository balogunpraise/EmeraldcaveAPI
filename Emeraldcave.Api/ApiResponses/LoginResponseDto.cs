using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emeraldcave.Api.ApiResponses
{
    public class LoginResponseDto
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
    }
}
