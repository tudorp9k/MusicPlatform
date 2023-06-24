using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Dtos
{
    public class FullAlbumDTO
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string ArtistName { get; set; }
        public List<SongDto> Songs { get; set; }
    }
}
