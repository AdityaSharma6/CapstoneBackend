﻿using capstone2022_backend.Models;
using Microsoft.Extensions.Options;
using System;
using MongoDB.Driver;

namespace capstone2022_backend.Services
{
	public class DoctorService
	{
        private readonly IMongoCollection<Doctor> _doctorCollection;

        public DoctorService(
            IOptions<DatabaseSettings> DatabaseSettings)
        {
            var mongoClient = new MongoClient(
                DatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                DatabaseSettings.Value.DatabaseName);

            _doctorCollection = mongoDatabase.GetCollection<Doctor>(
                DatabaseSettings.Value.DoctorCollectionName);
        }

        public async Task<List<Doctor>> GetAsync() =>
            await _doctorCollection.Find(_ => true).ToListAsync();

        public async Task<Doctor?> GetAsync(string id) =>
            await _doctorCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Doctor newDoctor) =>
            await _doctorCollection.InsertOneAsync(newDoctor);

        public async Task UpdateAsync(string id, Doctor updatedDoctor) =>
            await _doctorCollection.ReplaceOneAsync(x => x.Id == id, updatedDoctor);

        public async Task RemoveAsync(string id) =>
            await _doctorCollection.DeleteOneAsync(x => x.Id == id);
    }
}

