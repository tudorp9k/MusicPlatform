using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Dtos
{
    public class RegisterArtistDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
}
