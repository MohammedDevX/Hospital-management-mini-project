using Mini_projet.Interfaces;

namespace Mini_projet.Repositories
{
    public interface IRepository<T> where T : IIdentifiable
    {
        public T? GetById(Guid id);

        public IEnumerable<T> GetAll();

        public void Add(T item);

        public bool Delete(Guid id);

        public IEnumerable<T> Find(Func<T, bool> predicate);
    }
}
