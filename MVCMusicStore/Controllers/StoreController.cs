using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCMusicStore.Models;

namespace MVCMusicStore.Controllers
{
    public class StoreController : Controller
    {
        public MusicStoreContext StoreDb { get; }

        public StoreController(MusicStoreContext storeDb)
        {
            StoreDb = storeDb;
        }
        public IActionResult Index()
        {
            var genres = StoreDb.Genres.ToList();
            return View(genres);
        }

        public IActionResult Browse(string genre)
        {
            var genreModel = StoreDb.Genres.Include("Albums")
                .Single(g => g.Name == genre);
            return View(genreModel);
        }

        public IActionResult Details(int id)
        {
            var album = StoreDb.Albums.Find(id);
            return View(album);
        }
    }
}
