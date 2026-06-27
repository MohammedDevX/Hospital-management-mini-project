namespace Mini_projet.Interfaces
{
    // Contract that obligates classes who implement it to have an Id attribute
    public interface IIdentifiable
    {
        public Guid Id { get; init; }
    }
}
