using System;
using ccm.api.Settings;
using ccm.entities.DTOs;
using ccm.entities.Entities.Student;
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

        public Task<Scholarhip> Add(Scholarhip scholarhip, Guid UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Scholarhip>> GetAll()
        {
            return await scholarshipCollection.Find(x => true).ToListAsync();
        }

        public Task<Scholarhip> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Scholarhip> UpdateScholarShip(Guid scholarshipId, Scholarhip scholarhip, Guid UserId)
        {
            throw new NotImplementedException();
        }

        public Task<Scholarhip> UpdateScholarShipStatus(Guid scholarshipId, bool status, Guid UserId)
        {
            throw new NotImplementedException();
        }
    }
}