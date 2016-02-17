using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using MVCMusicStore5.Models;
using MVCMusicStore5.Models.GenreModels;
using MVCMusicStore5.Repositories;

namespace MVCMusicStore5.BusinessLogic
{
    public class BusinessMethods
    {
        public static List<GenreModel> GetGenres()
        {
            var repository = new GenreRepository();
            //ViewData["Genres"] =
            return repository.GetGenres().Select(g => new GenreModel { GenreId = g.GenreId, Name = g.Name, Description = g.Description })
                .ToList();
        }
        public static SelectList GetQuantityDictionary()
        {
            var quantityDictionary = GetDictionary();
            return
                new SelectList(
                    ((Dictionary<int, int>)quantityDictionary).Select(x => new { value = x.Key, text = x.Value }),
                    "value", "text");
        }

        public static Dictionary<int, int> GetDictionary()
        {
            var quantityDictionary = new Dictionary<int, int>();
            for (int i = 1; i <= 10; i++)
            {
                quantityDictionary.Add(i, i);
            }
            return quantityDictionary;
        }
    }
}
