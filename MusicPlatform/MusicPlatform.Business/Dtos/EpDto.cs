using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Dtos
{
    public class EpDto
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public int ArtistId { get; set; }
        public List<SongDto> Songs { get; set; }

    }
}
