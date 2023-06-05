﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Dtos
{
    public class SongUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int ArtistId { get; set; }
    }
}
