using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace To_Do_List.Interface
{
    public interface IRepository<TRequest,TResponse>
    {
        public TResponse AddItem(TRequest item);
        public TResponse GetItem(long id);
        public IEnumerable<TResponse> GetAll();
        public void RemoveItem(long id);
        public void UpdateItem(TResponse item);
        public bool ExistItem(TRequest item);
    }
}