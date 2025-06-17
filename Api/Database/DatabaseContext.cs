using MongoDB.Driver;

namespace Api.Database
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly IMongoDatabase _database;

        public DatabaseContext(IDatabaseClient client, string dataBase)
        {
            _database = client.Client.GetDatabase(dataBase);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
