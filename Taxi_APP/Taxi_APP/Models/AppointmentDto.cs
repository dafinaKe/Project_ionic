using System.ComponentModel.DataAnnotations;

namespace Taxi_APP.Models
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }

        public int Age { get; set; }
    }
}
