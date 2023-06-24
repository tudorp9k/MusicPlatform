using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Exceptions
{
    public class AlbumNotFoundException : ApplicationException
    {
        private static string defaultMessage = "Album not found";
        public AlbumNotFoundException() : base(defaultMessage) { }
        public AlbumNotFoundException(string message) : base(message) { }
    }
}
