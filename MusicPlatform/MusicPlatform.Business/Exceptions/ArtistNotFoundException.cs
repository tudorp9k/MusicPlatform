using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Exceptions
{
    public class ArtistNotFoundException : Exception
    {
        private static string defaultMessage = "Artist not found.";
        public ArtistNotFoundException() : base(defaultMessage) { }
        public ArtistNotFoundException(string message) : base(message) { }
    }
}
