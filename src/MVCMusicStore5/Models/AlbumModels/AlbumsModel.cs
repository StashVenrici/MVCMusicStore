using System;
using System.Collections.Generic;
using System.Linq;
using MVCMusicStore5.Entities;

namespace MVCMusicStore5.Models.AlbumModels
{
    public class AlbumsModel
    {
        public List<AlbumModel> Albums { get; set; }
        public Genre Genre { get; set; }
    }
}