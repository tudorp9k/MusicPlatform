using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Exceptions
{
    public class SongNotFoundException : ApplicationException
    {
        private static string defaultMessage = "Song not found.";
        public SongNotFoundException() : base(defaultMessage) { }
        public SongNotFoundException(string message) : base(message) { }
    }
}
