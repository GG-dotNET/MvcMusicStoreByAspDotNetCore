using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCMusicStore.Models;

namespace MVCMusicStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class StoreManagerController : Controller
    {
        public MusicStoreContext Db { get; }

        public StoreManagerController(MusicStoreContext db) => Db = db;

        public IActionResult Index()
        {
            var albums = Db.Albums.Include(a => a.Genre)
                .Include(a => a.Artist);
            return View(albums.ToList());
        }

        public IActionResult Details(int id)
        {
            Album album = Db.Albums.Find(id);
            return View(album);
        }

        public IActionResult Create()
        {
            ViewBag.GenreId = new SelectList(Db.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(Db.Artists, "ArtistId", "Name");
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                Db.Albums.Add(album);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(Db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(Db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        public IActionResult Edit(int id)
        {
            Album album = Db.Albums.Find(id);
            ViewBag.GenreId = new SelectList(Db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(Db.Artists, "ArtistId", "Name", album.ArtistId);

            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(album).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(Db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(Db.Artists, "ArtistId", "Name", album.ArtistId);
            
            return View(album);
        }

        public IActionResult Delete(int id)
        {
            Album album = Db.Albums.Find(id);
            return View(album);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Album album = Db.Albums.Find(id);
            Db.Albums.Remove(album);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
