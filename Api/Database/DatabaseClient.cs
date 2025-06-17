using MongoDB.Driver;

namespace Api.Database
{
    public class DatabaseClient : IDatabaseClient
    {
        private readonly MongoClient _client;

        public DatabaseClient(string connectionString)
        {
            _client = new MongoClient(connectionString);
        }

        public MongoClient Client => _client;
    }
}
