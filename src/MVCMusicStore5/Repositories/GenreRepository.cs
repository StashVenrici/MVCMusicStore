using System;
using System.Collections.Generic;
using System.Linq;
using MVCMusicStore5.Entities;

namespace MVCMusicStore5.Repositories
{
    public class GenreRepository
    {
        MusicStoreEntitiesDbContext _entities = new MusicStoreEntitiesDbContext();

        public List<Genre> GetGenres()
        {
            return _entities.Genres.ToList();
        }

        public Genre GetGenre(int genreId)
        {
            return _entities.Genres.FirstOrDefault(g => g.GenreId == genreId);
        }
            
    }
}