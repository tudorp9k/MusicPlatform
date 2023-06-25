using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Exceptions
{
    public class SingleNotFoundException : ApplicationException
    {
        private static string defaultMessage = "Single not found.";
        public SingleNotFoundException() : base(defaultMessage) { }
        public SingleNotFoundException(string message) : base(message) { }
    }
}
