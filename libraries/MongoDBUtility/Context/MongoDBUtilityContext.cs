using Data.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBUtility.Interface;

namespace MongoDBUtility.Context
{
    public class MongoDBUtilityContext : IMongoDBUtilityContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }

        public IClientSessionHandle Session { get; set; }

        public IMongoCollection<Book> BookCollection => _db.GetCollection<Book>("TestMongoCollectionDB");

        public MongoDBUtilityContext(IOptions<Mongosettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.Connection);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            return _db.GetCollection<T>(name);
        }
    }
}
