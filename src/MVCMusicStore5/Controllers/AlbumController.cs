using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using MVCMusicStore5.BusinessLogic;
using MVCMusicStore5.Entities;
using MVCMusicStore5.Models;
using MVCMusicStore5.Models.AlbumModels;
using MVCMusicStore5.Repositories;

namespace MVCMusicStore5.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult ViewAlbum(Guid id)
        {
            var repository = new AlbumRepository();
            var album = repository.GetAlbum(id);
            var model = (AlbumModel)AlbumLogic.AlbumToAlbumModel(album);
            ViewBag.QuantityDictionary = BusinessMethods.GetQuantityDictionary();
            return View(model);
        }


        public ActionResult ViewAlbumsByGenre(int id)
        {
            var model = BusinessLogic.AlbumLogic.GetAlbumsModel(id);
            return View("ViewAlbumByGenre", model);

        }

        public ActionResult ViewAlbums()
        {
            var model = AlbumLogic.GetAlbumsModel(null);
            return View("ViewAlbums", model);
        }

      
    }
}