using Data.Model;
using MongoDB.Driver;

namespace MongoDBUtility.Interface
{
    public interface IMongoDBUtilityContext
    {
        IMongoCollection<Book> GetCollection<Book>(string name);
        IMongoCollection<Book> BookCollection { get; }
    }
}
