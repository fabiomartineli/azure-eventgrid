using MongoDB.Driver;

namespace Api.Database
{
    public interface IDatabaseClient
    {
        MongoClient Client { get; }
    }
}
