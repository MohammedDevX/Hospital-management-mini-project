namespace Mini_projet.Exceptions
{
    public class ComfirmedAppointmentException : Exception
    {
        public ComfirmedAppointmentException() : base($"Only confirmed appointments can be completed")
        {
            
        }
    }
}
