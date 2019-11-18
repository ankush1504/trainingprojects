using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dropdown2ndpage.Models;

namespace dropdown2ndpage.Controllers
{
    public class HomeController : Controller
    {
        public moviesEntities mov = new moviesEntities();
       

        List<SelectListItem> LanguageList = new List<SelectListItem>()
        {
            new SelectListItem{Text="English",Value="1"},
            new SelectListItem{Text="Hindi",Value="2"},
            new SelectListItem{Text="Kannada",Value="3"}
        };

        List<SelectListItem> GenreList = new List<SelectListItem>()
        {
            new SelectListItem{Text="Action and Adventure",Value="1"},
            new SelectListItem{Text="Comedy",Value="2"},
            new SelectListItem{Text="Crime",Value="3"},
               new SelectListItem{Text="Documentary",Value="4"},
                  new SelectListItem{Text="Drama",Value="5"},
                     new SelectListItem{Text="Family",Value="6"},
                        new SelectListItem{Text="Kids",Value="7"},
                           new SelectListItem{Text="Mystery",Value="8"}

        };

        List<SelectListItem> SortList = new List<SelectListItem>()
        {
            new SelectListItem{Text="Trending",Value="1"},
            new SelectListItem{Text="Latest",Value="2"},
            new SelectListItem{Text="Top Rated",Value="3"},


        };

        public ActionResult Index()
        {

            moviesEntities1 mov1 = new moviesEntities1();
            usertable user = mov1.usertables.FirstOrDefault(x => x.Id == 1);
            return View();

        }

        public ActionResult Tv()
        {
            ViewBag.Language = LanguageList;
            ViewBag.Genre = GenreList;
            ViewBag.Sort = SortList;
            return View();

        }

        public ActionResult Movies(FormCollection form)
        {
            moviesEntities ent = new moviesEntities();
            string lang = form["selectedlanguage"].ToLower();
            ViewBag.Language = LanguageList;
            ViewBag.Genre = GenreList;
            ViewBag.Sort = SortList;
            return View(ent.movienames.Where(x => x.Language == lang || lang == null).ToList());
         
           
        }
        public ActionResult Movieslist(moviename mov)
        {
            moviesEntities ent = new moviesEntities();
            ViewBag.Language = LanguageList;
            ViewBag.Genre = GenreList;
            ViewBag.Sort = SortList;


            return View(ent.movienames.ToList()); ;
        }
        [HttpPost]
        public ActionResult Movieslist(FormCollection form,string search)
        {
            moviesEntities ent = new moviesEntities();
            var records = ent.movienames.AsQueryable();

            string lang = form["selectedlanguage"].ToLower();
            string gen = form["selectedgenre"].ToLower();
            string sort = form["selectedsort"];
            //string ser = form["search"].ToLower();

            ViewBag.Language = LanguageList;
            ViewBag.Genre = GenreList;
            ViewBag.Sort = SortList;


            if (gen == "" && lang != "")
            {
                records = ent.movienames.Where(x => x.Language == lang || x.Genre == null);
                switch (sort)
                {

                    case "Trending":
                        records = records.OrderByDescending(x => x.Likes);
                        break;

                    case "Top Rated":
                        records = records.OrderByDescending(x => x.Ratings);
                        break;

                    case "Latest":
                        records = records.OrderByDescending(x => x.Year);
                        break;

                    default:
                        records = records.OrderBy(x => x.Title);
                        break;
                }
            }
            else if (lang == "" && gen != "")
            {
                records = ent.movienames.Where(x => x.Genre == gen);
                switch (sort)
                {

                    case "Trending":
                        records = records.OrderByDescending(x => x.Likes);
                        break;

                    case "Top Rated":
                        records = records.OrderByDescending(x => x.Ratings);
                        break;

                    case "Latest":
                        records = records.OrderByDescending(x => x.Year);
                        break;

                    default:
                        records = records.OrderBy(x => x.Title);
                        break;
                }
            }
            else if (lang != "" && gen != "")
            {
                records = ent.movienames.Where(x => x.Language == lang && x.Genre == gen);
                switch (sort)
                {

                    case "Trending":
                        records = records.OrderByDescending(x => x.Likes);
                        break;

                    case "Top Rated":
                        records = records.OrderByDescending(x => x.Ratings);
                        break;

                    case "Latest":
                        records = records.OrderByDescending(x => x.Year);
                        break;

                    default:
                        records = records.OrderBy(x => x.Title);
                        break;
                }
            }
            else if (lang == "" && gen == "" && search != "")
            {
                records = ent.movienames.Where(x => x.Title.StartsWith(search.ToLower()) || search == null);
                switch (sort)
                {

                    case "Trending":
                        records = records.OrderByDescending(x => x.Likes);
                        break;

                    case "Top Rated":
                        records = records.OrderByDescending(x => x.Ratings);
                        break;

                    case "Latest":
                        records = records.OrderByDescending(x => x.Year);
                        break;

                    default:
                        records = records.OrderBy(x => x.Title);
                        break;
                }
            }
            else
            {
                records = ent.movienames.AsQueryable();
                switch (sort)
                {

                    case "Trending":
                        records = records.OrderByDescending(x => x.Likes);
                        break;

                    case "Top Rated":
                        records = records.OrderByDescending(x => x.Ratings);
                        break;

                    case "Latest":
                        records = records.OrderByDescending(x => x.Year);
                        break;

                    default:
                        records = records.OrderBy(x => x.Title);
                        break;


                }

            }
          


            return View(records);

        }
        public ActionResult MovieDetails(int id)
        {
            moviesEntities ent = new moviesEntities();
            
            moviename selectedMovie = (moviename)ent.movienames.FirstOrDefault(x => x.Id == id);
            
            return View(selectedMovie);
            
        }


        [HttpPost]
        public ActionResult MovieDetails(int id,FormCollection form)
        {
            moviesEntities ent = new moviesEntities();
           
            moviesEntities1 mov1 = new moviesEntities1();

            usertable user = mov1.usertables.FirstOrDefault(x => x.Id == 1);
           
            favlist selectedfavlist = mov1.favlists.Create();

            moviename selectedMovie = ent.movienames.FirstOrDefault(x => x.Id == id);
           
            string click = form["submit"];
            string favclick = form["fav"];

            if (click=="like")
            {

              
                selectedMovie.Likes = selectedMovie.Likes + 1;
                
                selectedMovie.likeclick = 1;
            
                ent.SaveChanges();
            }
            if(favclick=="favourite")
            {

                selectedfavlist.movietitle = selectedMovie.Title;
                selectedfavlist.userID = user.Id;
                mov1.favlists.Add(selectedfavlist);
                mov1.SaveChanges();
            }

            return View(selectedMovie);            
        }
    }
}