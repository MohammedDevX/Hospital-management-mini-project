namespace Mini_projet.Exceptions
{
    public class DoctorNotFoundException : Exception
    {
        public DoctorNotFoundException(Guid doctorId) : base($"Doctor {doctorId} not found")
        {
            
        }
    }
}
