using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Exceptions
{
    public class UserNotFoundException : ApplicationException
    {
        private static string defaultMessage = "User not found";
        public UserNotFoundException() : base(defaultMessage) { }
        public UserNotFoundException(string message) : base(message) { }
    }
}
