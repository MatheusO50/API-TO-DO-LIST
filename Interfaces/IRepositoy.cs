namespace To_Do_List.Interface
{
    public interface IRepositoy<TRequest,TResponse>
    {
        public TResponse AddItem(TRequest item);
        public TResponse GetItem(long id);
        public IEnumerable<TRequest> GetAll();
        public void RemoveItem(long id);
        public void UpdateItem(TRequest item);
    }
}