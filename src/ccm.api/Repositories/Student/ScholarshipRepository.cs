using System;
using ccm.api.Settings;
using ccm.entities.DTOs;
using ccm.entities.Entities.Student;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ccm.api.Repositories.Student
{
    public class ScholarshipRepository : IScholarshipRepository
    {
        private readonly IMongoCollection<Scholarship> scholarshipCollection;
        private readonly FilterDefinitionBuilder<Scholarship> filterBuilder = Builders<Scholarship>.Filter;

        public ScholarshipRepository(IMongoClient _mongoClient,
        DBSettings _dbSettings)
        {
            IMongoDatabase db = _mongoClient.GetDatabase(_dbSettings.DbName);
            scholarshipCollection = db.GetCollection<Scholarship>("Scholarship"); 
        }

        public async Task<Scholarship> Add(Scholarship scholarship, Guid UserId)
        {
            await scholarshipCollection.InsertOneAsync(scholarship);
            return scholarship;
        }

        public async Task<List<Scholarship>> GetAll()
        {
            return await scholarshipCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<List<Scholarship>> GetAllEnabled()
        {
            return await scholarshipCollection.Find(s => s.IsEnabled == true).ToListAsync();
        }

        public async Task<Scholarship> GetById(Guid Id)
        {
            var scholashipFilter = filterBuilder.Eq(i => i.Id,Id);
            return await scholarshipCollection.Find(scholashipFilter).SingleOrDefaultAsync();
        }

        public async Task<Scholarship> UpdateScholarShip(Guid scholarshipId, Scholarship scholaship, Guid UserId)
        {
            var scholashipFilter = filterBuilder.Eq(i => i.Id,scholarshipId);
            await scholarshipCollection.ReplaceOneAsync(scholashipFilter,scholaship);
            return scholaship;
        }

        public async Task<Scholarship> UpdateScholarShipStatus(Guid scholarshipId, Scholarship updatedS, Guid UserId)
        {
            var filter = filterBuilder.Eq(existingScholarship => existingScholarship.Id,scholarshipId);
            await scholarshipCollection.ReplaceOneAsync(filter,updatedS);
            return updatedS;

        }
    }
}