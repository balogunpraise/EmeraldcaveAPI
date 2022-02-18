using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emeraldcave.Api.ApiResponses
{
    public class AuthResponseDto
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
