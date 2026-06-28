namespace Mini_projet.Exceptions
{
    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException(Guid patientId) : base($"Patient {patientId} not found")
        {}
    }
}
