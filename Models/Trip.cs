using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Trips_Log_App.Models
{
    public class Trip
{
    // Create TripID primary key
    public int TripID { get; set; }

    // create Destination property, date start, date end 
    [Required(ErrorMessage = "Please enter a Destination.")]
    public string Destination { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a start date.")]
       
        public DateTime? StartDate { get; set; }

    [Required(ErrorMessage = "Please enter a end date.")]
       
        public DateTime? EndDate { get; set; }


    // create accomodation, phone number, and email
    [Required(ErrorMessage = "Please enter an accommodation name.")]
    public string Accommodation { get; set; } = string.Empty;


    public string? AccommodationPhoneNumber { get; set; }

    public string? AccommodationEmail { get; set; }



    // create Activity one, two, three properties, make them optional
    public string? ActivityOne { get; set; }
    public string? ActivityTwo { get; set; }

    public string? ActivityThree { get; set; }
}
}
