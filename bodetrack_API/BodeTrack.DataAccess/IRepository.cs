namespace BodeTrack.DataAccess
{
    internal interface IRepository<T>
    {
        public IEnumerable<T> List();

        public RequestStatus Insert(T item);

        public RequestStatus Update(T item);

        public RequestStatus Delete(int? id);

        public T Find(int? id);
    }
}