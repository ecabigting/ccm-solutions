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
        private readonly IMongoCollection<StudentScholarship> scholarshipCollection;
        private readonly FilterDefinitionBuilder<StudentScholarship> filterBuilder = Builders<StudentScholarship>.Filter;

        public ScholarshipRepository(IMongoClient _mongoClient,
        DBSettings _dbSettings)
        {
            IMongoDatabase db = _mongoClient.GetDatabase(_dbSettings.DbName);
            scholarshipCollection = db.GetCollection<StudentScholarship>("StudentScholarship"); 
        }

        public async Task<StudentScholarship> Add(StudentScholarship scholarship, Guid UserId)
        {
            await scholarshipCollection.InsertOneAsync(scholarship);
            return scholarship;
        }

        public async Task<List<StudentScholarship>> GetAll()
        {
            return await scholarshipCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<List<StudentScholarship>> GetAllEnabled()
        {
            return await scholarshipCollection.Find(s => s.IsEnabled == true).ToListAsync();
        }

        public async Task<StudentScholarship> GetById(Guid Id)
        {
            var scholashipFilter = filterBuilder.Eq(i => i.Id,Id);
            return await scholarshipCollection.Find(scholashipFilter).SingleOrDefaultAsync();
        }

        public async Task<StudentScholarship> UpdateScholarShip(Guid scholarshipId, StudentScholarship scholaship, Guid UserId)
        {
            var scholashipFilter = filterBuilder.Eq(i => i.Id,scholarshipId);
            await scholarshipCollection.ReplaceOneAsync(scholashipFilter,scholaship);
            return scholaship;
        }

        public async Task<StudentScholarship> UpdateScholarShipStatus(Guid scholarshipId, StudentScholarship updatedS, Guid UserId)
        {
            var filter = filterBuilder.Eq(existingScholarship => existingScholarship.Id,scholarshipId);
            await scholarshipCollection.ReplaceOneAsync(filter,updatedS);
            return updatedS;

        }
    }
}