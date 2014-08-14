using System.Linq;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace WebAPIDemo.Models
{
    public interface IRepository
    {
        string MetaData();
        SaveResult SaveChanges(JObject saveBundle);
        IQueryable<Book> Books();
        IQueryable<Order> Orders();
    }
}