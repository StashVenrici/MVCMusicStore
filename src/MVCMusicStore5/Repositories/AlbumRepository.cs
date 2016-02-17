using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using MVCMusicStore5.Entities;

namespace MVCMusicStore5.Repositories
{
    public class AlbumRepository
    {
        MusicStoreEntitiesDbContext _entities = new MusicStoreEntitiesDbContext();

        public Album GetAlbum(Guid albumId)
        {
           return _entities.Albums.FirstOrDefault(a => a.Id == albumId);
        }

        public List<Album> GetAlbums(int? genreId)
        {
            if (genreId.HasValue)
            {
                return _entities.Albums.Where(a => a.GenreId == (int) genreId).ToList();
            }

            return _entities.Albums.ToList();
        }

        public void AddAlbum(Album album)
        {
            _entities.Albums.Add(new Album
            {
                Id = Guid.NewGuid(), ArtistId = album.ArtistId, GenreId = album.GenreId,
                    Price = album.Price, Title = album.Title
            });
            _entities.SaveChanges();
        }

        public void EditAlbum(Album album)
        {
            _entities.Entry(album).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public void DeleteAlbum(Guid albumId)
        {
            var album = _entities.Albums.FirstOrDefault(a => a.Id == albumId);
            _entities.Albums.Remove(album);
            _entities.SaveChanges();
        }
    }

}