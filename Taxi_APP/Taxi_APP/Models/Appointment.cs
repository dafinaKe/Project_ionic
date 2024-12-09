using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxi_APP.Models
{
    public class Appointment
    {


        [Key]
        public int AppointmentId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Location { get; set; }

        public int Age { get; set; }
    }
}
