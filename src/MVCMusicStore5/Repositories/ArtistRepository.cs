using System;
using System.Collections.Generic;
using System.Linq;
using MVCMusicStore5.Entities;

namespace MVCMusicStore5.Repositories
{
    public class ArtistRepository
    {
        MusicStoreEntitiesDbContext _entities = new MusicStoreEntitiesDbContext();

        public List<Artist> GetArtists()
        {
            return _entities.Artists.ToList();
        }

        public Artist GetArtist(int artistId)
        {
            return _entities.Artists.FirstOrDefault(a => a.ArtistId == artistId);
        }
    }
}