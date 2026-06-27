using Mini_projet.Events;
using Mini_projet.Models;
using Mini_projet.Repositories;

namespace Mini_projet.Services
{
    public class AppointmentService(
        IRepository<Doctor> _doctorRepository, 
        IRepository<Patient> _patientRepository, 
        IRepository<Appointment> _appointmentRepository)
    {
        public event EventHandler<AppointmentCreatedEventArgs> appointmentCreatedEvent;

        public void ReserveAppointment(Guid patientId, Guid doctorId, DateTime appointmentDate)
        {
            var patient = _patientRepository.GetById(patientId);
            if (patient == null)
            {
                throw new ArgumentException("Patient not found");
            }

            var doctor = _doctorRepository.GetById(doctorId);
            if (doctor == null)
            {
                throw new ArgumentException("Doctor not found");
            }

            bool disponibility = AppointmentDateAndDoctorDisponibility(appointmentDate, doctor.Id);
            if (!disponibility)
            {
                throw new ArgumentException("Doctor or date are not available");
            }

            Appointment appointment = new()
            {
                Doctor = doctor,
                Patient = patient,
                ScheduledAt = appointmentDate
            };

            _appointmentRepository.Add(appointment);

            var eventArgs = new AppointmentCreatedEventArgs()
            {
                Doctor = doctor,
                Patient = patient,
                ShedualedAt = appointmentDate
            };

            appointmentCreatedEvent?.Invoke(this, eventArgs); // Notify and trigger subscribers
        }

        private bool AppointmentDateAndDoctorDisponibility(DateTime date, Guid doctorId)
        {
            var dateAndDoctorAvailability = _appointmentRepository.Find(a => a.ScheduledAt == date && a.Doctor.Id == doctorId).Any();
            if (dateAndDoctorAvailability)
            {
                return false;
            }

            return true;
        }
    }
}
