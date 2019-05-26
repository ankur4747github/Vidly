using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrel!" };
            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Customers = customers,
                Movie = movie
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("ID = " + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content("PageIndex = " + pageIndex + "Sory By = " + sortBy);
        }

        [Route("movies/release/{year:regex(\\d{4})}/{month:maxlength(2)}")]
        //Constraints min max minlenght maxlength int float guid
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content("Year = " + year + " Month = " + month);
        }
    }
}