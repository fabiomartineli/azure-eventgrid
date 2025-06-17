using MongoDB.Driver;

namespace Api.Database
{
    public interface IDatabaseContext
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
