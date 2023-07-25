using GroceryStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GroceryStoreApi.Services
{
    public class GroceryService
    {
        private readonly IMongoCollection<Grocery> _groceryCollection;

        public GroceryService(IOptions<GroceryStoreDatabaseSettings> groceryStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(groceryStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(groceryStoreDatabaseSettings.Value.DatabaseName);

            _groceryCollection = mongoDatabase.GetCollection<Grocery>(groceryStoreDatabaseSettings.Value.GroceryCollectionName);
        }

        public async Task<List<Grocery>> GetAsync() =>
            await _groceryCollection.Find(_ => true).ToListAsync();

        public async Task<Grocery?> GetAsync(string id) =>
            await _groceryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Grocery newGrocery) =>
            await _groceryCollection.InsertOneAsync(newGrocery);

        public async Task UpdateAsync(string id, Grocery updateGrocery) =>
            await _groceryCollection.ReplaceOneAsync(x => x.Id == id, updateGrocery);

        public async Task RemoveAsync(string id)  =>
            await _groceryCollection.DeleteOneAsync(x => x.Id == id);
    }
}
