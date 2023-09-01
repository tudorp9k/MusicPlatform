using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Dtos
{
    public class AuthenticateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
