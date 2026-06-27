using Mini_projet.Models;
using Mini_projet.Repositories;
using System.Xml.Serialization;

namespace Mini_projet.Services.MedicalRecords
{
    public class MedicalRecordService(
        IRepository<MedicalRecord> _medicalRecordRepository,
        IRepository<Appointment> _appointmentRepository
        ) : IMedicalRecordService
    {
        public void CreateMedicalRecord(Guid doctorId, Guid appointmentId, string diagnosis)
        {
            var appointment = _appointmentRepository.Find(a => a.Doctor.Id == doctorId
                            && a.Id == appointmentId && a.Status == Enums.AppointmentStatus.Completed).FirstOrDefault();

            //if (_medicalRecordRepository.Find(m => m.Appointment.Id == appointmentId).Any())
            //{
            //    throw new InvalidDataException();
            //}

            if (appointment.MedicalRecord is not null || appointment is null)
            {
                throw new InvalidOperationException();
            }

            MedicalRecord medicalRecord = new()
            {
                Doctor = appointment.Doctor,
                Patient = appointment.Patient,
                Diagnosis = diagnosis,
                Appointment = appointment
            };

            appointment.MedicalRecord = medicalRecord;

            _medicalRecordRepository.Add(medicalRecord);
        }
    }
}
