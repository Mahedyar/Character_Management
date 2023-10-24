using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.Models.Identity
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
