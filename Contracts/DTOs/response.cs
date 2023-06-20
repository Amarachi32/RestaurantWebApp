using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTOs
{
    public class UserResponse
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }

    public class ApiResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
