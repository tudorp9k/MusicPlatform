using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Exceptions
{
    public class PlaylistNotFoundException : ApplicationException
    {
        private static string defaultMessage = "Playlist not found.";
        public PlaylistNotFoundException() : base(defaultMessage) { }
        public PlaylistNotFoundException(string message) : base(message) { }
    }
}
