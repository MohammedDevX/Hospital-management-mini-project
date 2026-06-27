using Mini_projet.Events;
using Mini_projet.Models;
using Mini_projet.Repositories;
using Mini_projet.Services;
using Mini_projet.Enums;
using Mini_projet.Features.Handlers;

// Dependencies : 
IRepository<Doctor> doctor = new Repository<Doctor>();
IRepository<Patient> patient = new Repository<Patient>();
IRepository<Appointment> appointment = new Repository<Appointment>();
IRepository<Department> department = new Repository<Department>();

// Appointment service : 
AppointmentService appointmentService = new(doctor , patient, appointment);

EmailSenderEventHandler emailSnder = new();
LogEventHandler log = new();

appointmentService.appointmentCreatedEvent += emailSnder.Notify;
appointmentService.appointmentCreatedEvent += log.AppointmentCretatedLog;

Department department1 = new() 
{ 
    Name = "Cardiologie department",
    Floor = 3,
    PhoneNumber = "0637096748"
};
department.Add(department1);

Doctor d1 = new()
{
    FullName = "Bakhtaoui Mohammed",
    Speciality = DoctorSpeciality.Cardiologist,
    Department = department1
};
doctor.Add(d1);

Patient p1 = new()
{
    FullName = "Bakhtaoui Acharf",
    Age = 17,
    Email = "achraf@gmail.com"
};
patient.Add(p1);

appointmentService.ReserveAppointment(p1.Id, d1.Id, new DateTime(2026, 6, 27, 16, 30, 0));
appointmentService.ReserveAppointment(p1.Id, d1.Id, new DateTime(2026, 6, 27, 16, 30, 1));

foreach (var item in appointment.GetAll())
{
    Console.WriteLine(item.ScheduledAt);
}