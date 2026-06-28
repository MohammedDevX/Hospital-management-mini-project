using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_projet.Exceptions
{
    public class AppointmentAndDoctorAvailabilityException : Exception
    {
        public AppointmentAndDoctorAvailabilityException() : base("Appointment date or doctor not available")
        {
            
        }
    }
}
