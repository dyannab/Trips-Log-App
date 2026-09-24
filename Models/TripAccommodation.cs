using System.ComponentModel.DataAnnotations;
namespace Trips_Log_App.Models

{
    public class TripAccommodation
{
   
    public string Accommodation { get; set; } = string.Empty;

    // create optional phone number property
    public string? AccommodationPhoneNumber { get; set; }

    // create optional email property
    public string? AccommodationEmail { get; set; }

    // create Subhead display
    public string? Destination { get; set; }

}
}
