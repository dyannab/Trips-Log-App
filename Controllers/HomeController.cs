
using Microsoft.AspNetCore.Mvc;
using Trips_Log_App.Models;

namespace Trips_Log_App.Controllers
{
    public class HomeController : Controller
    {

       
        private TripsContext context { get; set; }

        public HomeController(TripsContext ctx) => context = ctx;



        // order trips by destination
        public IActionResult Index()
        {
            var trips = context.Trips.OrderBy(m => m.Destination).ToList();

           

            return View(trips);

        }




    }
}
