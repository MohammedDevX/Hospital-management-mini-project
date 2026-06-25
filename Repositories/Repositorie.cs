namespace Mini_projet.Repositories
{
    /* - Sumuary : 
     * This is generique repository so he can work with any model class with out defining it explicitly
     * The same in Find() method, thunks for c# who provide delegates that allow us to find object with specefique condition
        in collection, also it works with different classes 
    */
    public class Repositorie<T> where T : IIdentifiable
    {
        private readonly List<T> items = new();

        public T? GetById(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            return items;
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public bool Delete(int id)
        {
            var existringItem = items.FirstOrDefault(i => i.Id == id);
            if (existringItem == null)
            {
                return false;
            }

            items.Remove(existringItem);

            return true;
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            foreach (var item1 in items)
            {
                if (predicate(item1))
                {
                    yield return item1;
                }
            }
        }
    }
}
