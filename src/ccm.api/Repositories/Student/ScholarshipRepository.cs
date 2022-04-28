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
        private readonly IMongoCollection<Scholarhip> scholarshipCollection;
        private readonly FilterDefinitionBuilder<Scholarhip> filterBuilder = Builders<Scholarhip>.Filter;

        public ScholarshipRepository(IMongoClient _mongoClient,
        DBSettings _dbSettings)
        {
            IMongoDatabase db = _mongoClient.GetDatabase(_dbSettings.DbName);
            scholarshipCollection = db.GetCollection<Scholarhip>("Scholarhip"); 
        }

        public async Task<Scholarhip> Add(Scholarhip scholarhip, Guid UserId)
        {
            await scholarshipCollection.InsertOneAsync(scholarhip);
            return scholarhip;
        }

        public async Task<List<Scholarhip>> GetAll()
        {
            return await scholarshipCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Scholarhip> GetById(Guid Id)
        {
            var scholarhipFilter = filterBuilder.Eq(i => i.Id,Id);
            return await scholarshipCollection.Find(scholarhipFilter).SingleOrDefaultAsync();
        }

        public async Task<Scholarhip> UpdateScholarShip(Guid scholarshipId, Scholarhip scholarhip, Guid UserId)
        {
            var scholarhipFilter = filterBuilder.Eq(i => i.Id,scholarshipId);
            await scholarshipCollection.ReplaceOneAsync(scholarhipFilter,scholarhip);
            return scholarhip;
        }

        public Task<Scholarhip> UpdateScholarShipStatus(Guid scholarshipId, bool status, Guid UserId)
        {
            var scholarhipFilter = filterBuilder.Eq(i => i.Id,scholarshipId);
            var foundScholarship = scholarshipCollection.Find(scholarhipFilter).SingleOrDefaultAsync();
            if(foundScholarship != null)
            {
                foundScholarship
            }
            return null;
        }
    }
}