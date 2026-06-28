using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_projet.Exceptions
{
    public class AppointmentNotFoundException : Exception
    {
        public AppointmentNotFoundException(Guid appointmentId) : base($"Appointment {appointmentId} not found")
        {
            
        }
    }
}
