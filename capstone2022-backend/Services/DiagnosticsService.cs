using capstone2022_backend.Models;
using Microsoft.Extensions.Options;
using System;
using MongoDB.Driver;

namespace capstone2022_backend.Services
{
	public class DiagnosticsService
	{
        private readonly IMongoCollection<Diagnostics> _diagnosticCollection;

        public DiagnosticsService(
            IOptions<DatabaseSettings> DatabaseSettings)
        {
            var mongoClient = new MongoClient(
                DatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                DatabaseSettings.Value.DatabaseName);

            _diagnosticCollection = mongoDatabase.GetCollection<Diagnostics>(
                DatabaseSettings.Value.DiagnosticCollectionName);
        }

        public async Task<List<Diagnostics>> GetAsync() =>
            await _diagnosticCollection.Find(_ => true).ToListAsync();

        public async Task<Diagnostics?> GetAsync(string id) =>
            await _diagnosticCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Diagnostics newDiagnostic) =>
            await _diagnosticCollection.InsertOneAsync(newDiagnostic);

        public async Task UpdateAsync(string id, Diagnostics updatedDiagnostic) =>
            await _diagnosticCollection.ReplaceOneAsync(x => x.Id == id, updatedDiagnostic);

        public async Task RemoveAsync(string id) =>
            await _diagnosticCollection.DeleteOneAsync(x => x.Id == id);
    }
}

