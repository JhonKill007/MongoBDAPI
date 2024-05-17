using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBAPI.Repositories
{
    public class ProductCollection : IProductCollection
    {
        internal MongoDBRepository _repository;
        private IMongoCollection<Product> Collection;

        public ProductCollection(MongoDBRepository repository)
        {
            _repository = repository;
            Collection = _repository.db.GetCollection<Product>("Products");

        }
        public async Task DeleteProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } })
                .Result.FirstAsync();
        }

        public async Task InsertProduct(Product product)
        {
            await Collection.InsertOneAsync(product);
        }

        public async Task UpdateProduct(Product product)
        {
            var filter = Builders<Product>
                .Filter
                .Eq(x => x.Id, product.Id);
            await Collection.ReplaceOneAsync(filter, product);
        }
    }
}
