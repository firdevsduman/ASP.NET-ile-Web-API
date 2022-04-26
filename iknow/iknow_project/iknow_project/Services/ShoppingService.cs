using iknow_project.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace iknow_project.Services
{
    public class ShoppingService
    {
        private readonly IMongoCollection<Product> _productsCollection;

        public ShoppingService(
            IOptions<ShoppingDatabaseSettings> shoppingDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                shoppingDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                shoppingDatabaseSettings.Value.DatabaseName);

            _productsCollection = mongoDatabase.GetCollection<Product>(
                shoppingDatabaseSettings.Value.ProductsCollectionName);
        }
        /*
        /GetAll islemine karsılık geliyor 
        */
        public async Task<List<Product>> GetAsync() =>
            await _productsCollection.Find(_ => true).ToListAsync();
        
        /*
        /GetById islemine karsılık geliyor 
        */
        public async Task<Product?> GetAsync(string id) =>
            await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        /*
        /Create islemine karsılık geliyor 
        */
        public async Task CreateAsync(Product newProduct) =>
            await _productsCollection.InsertOneAsync(newProduct);

        /*
        /Update islemine karsılık geliyor 
        */
        public async Task UpdateAsync(string id, Product updatedProduct) =>
            await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

        /*
        /Sadece istediğimiz veriyi silmek için kullanılan kısım.
        */
        public async Task RemoveAsync(string id) =>
            await _productsCollection.DeleteOneAsync(x => x.Id == id);

        /*
        /Kayıtlı olan bütün veriyi silmek için kullanılan kısım.
        */
        public async Task RemoveAsync() =>
          await _productsCollection.DeleteManyAsync(_ => true);
    }
}