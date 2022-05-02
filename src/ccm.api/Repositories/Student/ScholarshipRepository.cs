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
        private readonly IMongoCollection<Scholaship> scholarshipCollection;
        private readonly FilterDefinitionBuilder<Scholaship> filterBuilder = Builders<Scholaship>.Filter;

        public ScholarshipRepository(IMongoClient _mongoClient,
        DBSettings _dbSettings)
        {
            IMongoDatabase db = _mongoClient.GetDatabase(_dbSettings.DbName);
            scholarshipCollection = db.GetCollection<Scholaship>("Scholaship"); 
        }

        public async Task<Scholaship> Add(Scholaship scholaship, Guid UserId)
        {
            await scholarshipCollection.InsertOneAsync(scholaship);
            return scholaship;
        }

        public async Task<List<Scholaship>> GetAll()
        {
            return await scholarshipCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<List<Scholaship>> GetAllEnabled()
        {
            return await scholarshipCollection.Find(s => s.IsEnabled == true).ToListAsync();
        }

        public async Task<Scholaship> GetById(Guid Id)
        {
            var scholashipFilter = filterBuilder.Eq(i => i.Id,Id);
            return await scholarshipCollection.Find(scholashipFilter).SingleOrDefaultAsync();
        }

        public async Task<Scholaship> UpdateScholarShip(Guid scholarshipId, Scholaship scholaship, Guid UserId)
        {
            var scholashipFilter = filterBuilder.Eq(i => i.Id,scholarshipId);
            await scholarshipCollection.ReplaceOneAsync(scholashipFilter,scholaship);
            return scholaship;
        }

        public async Task<Scholaship> UpdateScholarShipStatus(Guid scholarshipId, Scholaship updatedS, Guid UserId)
        {
            var filter = filterBuilder.Eq(existingScholarship => existingScholarship.Id,scholarshipId);
            await scholarshipCollection.ReplaceOneAsync(filter,updatedS);
            return updatedS;

        }
    }
}