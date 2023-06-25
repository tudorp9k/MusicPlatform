using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Exceptions
{
    public class EpNotFoundException : ApplicationException
    {
        private static string defaultMessage = "EP not found";
        public EpNotFoundException() : base(defaultMessage) { }
        public EpNotFoundException(string message) : base(message) { }
    }
}
