using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MVCMusicStore5.Entities;

namespace MVCMusicStore5.Models.AlbumModels
{
    public class AlbumModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is required")]
        public int GenreId { get; set; }
        [Display(Name = "Artist")]
        [Required(ErrorMessage = "Artist is required")]
        public int ArtistId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Genre")]
        public Genre Genre { get; set; }
        [Display(Name = "Artist")]
        public Artist Artist { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}