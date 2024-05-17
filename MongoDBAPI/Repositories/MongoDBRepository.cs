using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace MongoDBAPI.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;
        public readonly string _connectionString;
        public MongoDBRepository(string connectionString)
        {
            _connectionString = connectionString;
            GetConnection();
        }
        public void GetConnection()
        {
            client = new MongoClient(_connectionString);
            db = client.GetDatabase("Inventory");
        }

    }
}
