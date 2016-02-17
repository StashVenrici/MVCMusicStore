using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCMusicStore5.Entities;
using MVCMusicStore5.Models;
using MVCMusicStore5.Models.AlbumModels;
using MVCMusicStore5.Repositories;

namespace MVCMusicStore5.BusinessLogic
{
    public class AlbumLogic
    {
        public static AlbumsModel GetAlbumsModel(int? genreId)
        {
            var albumRepository = new AlbumRepository();
            var model = new AlbumsModel();
            model.Albums =
                albumRepository.GetAlbums(genreId)
                    .Select(
                        album =>
                          AlbumToAlbumModel(album))
                    .ToList();
            if (genreId.HasValue)
            {
                var genreRepository = new GenreRepository();
                model.Genre = genreRepository.GetGenre((int)genreId);
            }
            return model;
        }

        public static AlbumModel AlbumToAlbumModel(Album album)
        {
            var model =  new AlbumModel()
            {
                Id = album.Id,
                Title = album.Title,
                Price = album.Price
            };
            var genreRepository = new GenreRepository();
            model.Genre = genreRepository.GetGenre(album.GenreId);
            var artistRepository = new ArtistRepository();
            model.Artist = artistRepository.GetArtist(album.ArtistId);

            return model;
        }
    }
}
