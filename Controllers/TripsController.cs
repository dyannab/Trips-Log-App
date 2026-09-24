using Trips_Log_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Trips_Log_App.Controllers
{
    public class TripsController : Controller
    {
        private TripsContext context { get; set; }
        public TripsController(TripsContext ctx) => context = ctx;

        // create AddDestination action methods for Get and Post 
        [HttpGet]
        public IActionResult AddDestination()
        {
            ViewData["Banner"] = "Add Hotel, Trip Destination, and Dates";
            ViewBag.Action = "Add";
            return View(new Trip());
        }


        // create AddDestination action methods for Get and Post //
        
        // Saves the trip destination, accommodation, start date,
        // and end date to TempData and redirects to AddInfo action.
        
       
        [HttpPost]
        public IActionResult AddDestination(Trip trip)
        {
            if (ModelState.IsValid)
            {
                TempData["Destination"] = trip.Destination;
                TempData["Accommodation"] = trip.Accommodation;
                TempData["StartDate"] = trip.StartDate?.ToString("d");
                TempData["EndDate"] = trip.EndDate?.ToString("d");
                return RedirectToAction("AddInfo");
            }

            ViewData["Banner"] = "Add Hotel, Trip Destination, and Dates";
            return View(trip);
        }
        // create AddInfo action methods for Get and Post

        // Saves the accommodation info to TempData and redirects to AddThingsToDo action.
        [HttpGet]
        public IActionResult AddInfo()
        {
            ViewData["Banner"] = "Add Trip Accommodations";
            ViewBag.SubHeader = $"Enter Info for {TempData["Accommodation"]}";
            TempData.Keep();
            return View(new TripAccommodation());
        }


        
        
        
        
        
        
        
        
        
        
       
        
        
        [HttpPost]
        // Saves the accommodation info to TempData and redirects to AddThingsToDo action.
        public IActionResult AddInfo(TripAccommodation info)
        {
            if (ModelState.IsValid)
            {
                TempData["AccommodationPhoneNumber"] = info.AccommodationPhoneNumber;
                TempData["AccommodationEmail"] = info.AccommodationEmail;
                return RedirectToAction("AddThingsToDo");
            }

            ViewBag.SubHeader = $"Enter Info for {TempData["Accommodation"]}";
            TempData.Keep();
            return View(info);
        }

        // displays AddThingsToDo view and saves trip activities to database

        // create AddThingsToDo action methods for Get and Post
        [HttpGet]
        public IActionResult AddThingsToDo()
        {
            ViewBag.SubHeader = $"Enter Things To Do in {TempData["Destination"]}";
            TempData.Keep();
            return View(new TripActivities());
        }



        [HttpPost]
        public IActionResult AddThingsToDo(TripActivities activities)
        {
            // if the model state is valid, create a new  trip object and save to database

            if (ModelState.IsValid)
            {
                Trip newTrip = new()
                {
                    Destination = TempData["Destination"]?.ToString() ?? "",
                    StartDate = DateTime.Parse(TempData["StartDate"]?.ToString() ?? DateTime.Now.ToString()),
                    EndDate = DateTime.Parse(TempData["EndDate"]?.ToString() ?? DateTime.Now.ToString()),
                    Accommodation = TempData["Accommodation"]?.ToString() ?? "",
                    AccommodationPhoneNumber = TempData["AccommodationPhoneNumber"]?.ToString(),
                    AccommodationEmail = TempData["AccommodationEmail"]?.ToString(),
                    ActivityOne = activities.ActivityOne,
                    ActivityTwo = activities.ActivityTwo,
                    ActivityThree = activities.ActivityThree
                };

                context.Trips.Add(newTrip);
                context.SaveChanges();

                TempData.Clear();
                TempData["SuccessMessage"] = $"Trip to {newTrip.Destination} added.";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.SubHeader = $"Enter Things To Do for {TempData["Destination"]}";
            TempData.Keep();
            return View(activities);
        }

     


    }
}
