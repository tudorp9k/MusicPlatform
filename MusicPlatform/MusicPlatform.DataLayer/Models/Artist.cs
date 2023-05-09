using MusicPlatform.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.DataLayer.Models
{
    internal class Artist : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
