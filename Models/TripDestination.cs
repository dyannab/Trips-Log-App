using System.ComponentModel.DataAnnotations;
namespace Trips_Log_App.Models
{
    public class TripDestination
    {
        [Required]
        // Create Destination property
        public string Destination { get; set; } = string.Empty;
        // create Date Start property

       
        [Required]
        public DateTime? StartDate { get; set; }

        // create Date End property
        [Required]
        public DateTime? EndDate { get; set; }
    }
}
