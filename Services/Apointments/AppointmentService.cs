using Mini_projet.Events;
using Mini_projet.Exceptions;
using Mini_projet.Models;
using Mini_projet.Repositories;

namespace Mini_projet.Services.Apointments
{
    public class AppointmentService(
        IRepository<Doctor> _doctorRepository, 
        IRepository<Patient> _patientRepository, 
        IRepository<Appointment> _appointmentRepository)
    {
        public event EventHandler<AppointmentCreatedEventArgs> AppointmentCreatedEvent;
        public event EventHandler<AppointmentCancelledAndCompletedEventArgs> AppointmentCanceledByPatientEvent;
        public event EventHandler<AppointmentCancelledAndCompletedEventArgs> AppointmentCanceledByDoctorEvent;
        public event EventHandler<AppointmentCancelledAndCompletedEventArgs> AppointmentCompleltedEvent;

        public void ReserveAppointment(Guid patientId, Guid doctorId, DateTime appointmentDate)
        {
            var patient = _patientRepository.GetById(patientId);
            if (patient == null)
            {
                throw new PatientNotFoundException(patientId);
            }

            var doctor = _doctorRepository.GetById(doctorId);
            if (doctor == null)
            {
                throw new DoctorNotFoundException(doctorId);
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

            patient.Appointments.Add(appointment);
            doctor.Appointments.Add(appointment);

            var eventArgs = new AppointmentCreatedEventArgs()
            {
                Id = appointment.Id,
                Doctor = doctor,
                Patient = patient,
                ShedualedAt = appointmentDate
            };

            AppointmentCreatedEvent?.Invoke(this, eventArgs); // Notify and trigger subscribers
        }

        private bool AppointmentDateAndDoctorDisponibility(DateTime date, Guid doctorId)
        {
            var dateAndDoctorAvailability = _appointmentRepository.Find(
                a => a.Status == Enums.AppointmentStatus.Confirmed && a.ScheduledAt == date 
                && a.Doctor.Id == doctorId).Any();
            if (dateAndDoctorAvailability)
            {
                return false;
            }

            return true;
        }

        public void CancelAppointmentByPatient(Guid patientId, Guid appointmentId)
        {
            var appointment = _appointmentRepository.Find(a => a.Patient.Id == patientId &&
            a.Id == appointmentId && a.Status == Enums.AppointmentStatus.Confirmed).FirstOrDefault();
            if (appointment == null)
            {
                throw new ArgumentException("This appointment doesn't existe");
            }

            appointment.Status = Enums.AppointmentStatus.Cancelled;

            var eventArgs = new AppointmentCancelledAndCompletedEventArgs()
            {
                Id = appointment.Id,
                Doctor = appointment.Doctor,
                Patient = appointment.Patient,
                ShedualedAt = appointment.ScheduledAt
            };

            AppointmentCanceledByPatientEvent?.Invoke(this, eventArgs);
        }

        public void CancelAppointmentByDoctor(Guid doctorId, Guid appointmentId)
        {
            var appointment = _appointmentRepository.Find(a => a.Doctor.Id == doctorId &&
            a.Id == appointmentId && a.Status == Enums.AppointmentStatus.Confirmed).FirstOrDefault();
            if (appointment == null)
            {
                throw new ArgumentException("This appointment doesn't existe");
            }

            appointment.Status = Enums.AppointmentStatus.Cancelled;

            var eventArgs = new AppointmentCancelledAndCompletedEventArgs()
            {
                Id = appointment.Id,
                Doctor = appointment.Doctor,
                Patient = appointment.Patient,
                ShedualedAt = appointment.ScheduledAt
            };

            AppointmentCanceledByDoctorEvent?.Invoke(this, eventArgs);
        }

        public void CompleteAppointment(Guid doctorId, Guid appointmentId)
        {
            var appointment = _appointmentRepository.Find(a => a.Doctor.Id == doctorId && a.Id == appointmentId &&
            a.Status == Enums.AppointmentStatus.Confirmed).FirstOrDefault();

            if (appointment == null)
            {
                throw new ComfirmedAppointmentException();
            }

            appointment.Status = Enums.AppointmentStatus.Completed;

            var eventArgs = new AppointmentCancelledAndCompletedEventArgs()
            {
                Id = appointment.Id,
                Doctor = appointment.Doctor,
                Patient = appointment.Patient,
                ShedualedAt = appointment.ScheduledAt
            };

            AppointmentCompleltedEvent?.Invoke(this, eventArgs);
        }
    }
}
