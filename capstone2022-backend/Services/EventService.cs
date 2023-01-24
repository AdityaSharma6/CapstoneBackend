using System;
using capstone2022_backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace capstone2022_backend.Services
{
	public class EventService
	{
        private readonly IMongoCollection<Event> _eventCollection;

        public EventService(
            IOptions<DatabaseSettings> DatabaseSettings)
        {
            var mongoClient = new MongoClient(
                DatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                DatabaseSettings.Value.DatabaseName);

            _eventCollection = mongoDatabase.GetCollection<Event>(
                DatabaseSettings.Value.EventCollectionName);
        }

        public async Task<List<Event>> GetAsync() =>
            await _eventCollection.Find(_ => true).ToListAsync();

        public async Task<Event?> GetAsync(string id) =>
            await _eventCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Event newEvent) =>
            await _eventCollection.InsertOneAsync(newEvent);

        public async Task UpdateAsync(string id, Event updatedEvent) =>
            await _eventCollection.ReplaceOneAsync(x => x.Id == id, updatedEvent);

        public async Task RemoveAsync(string id) =>
            await _eventCollection.DeleteOneAsync(x => x.Id == id);
    }
}

