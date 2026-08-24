namespace To_Do_List.Interface
{
    public interface IService<TRequest, TResponse>
    {
        public TResponse AddItem(TRequest item);
        public TResponse GetItem(long id);
        public IEnumerable<TResponse> GetAll();
        public void RemoveItem(long id);
        public void UpdateItem(TResponse item);
    }
}