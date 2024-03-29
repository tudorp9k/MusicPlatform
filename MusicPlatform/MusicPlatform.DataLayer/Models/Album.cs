﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.DataLayer.Models
{
    public class Album : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
