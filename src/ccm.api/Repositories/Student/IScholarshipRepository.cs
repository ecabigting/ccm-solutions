using System;
using ccm.entities.Entities.Student;

namespace ccm.api.Repositories.Student
{
    public interface IScholarshipRepository
    {
        Task<List<Scholarhip>> GetAll();
        Task<List<Scholarhip>> GetAllEnabled();
        Task<Scholarhip> GetById(Guid Id);
        Task<Scholarhip> UpdateScholarShip(Guid scholarshipId,Scholarhip scholarhip,Guid UserId);
        Task<Scholarhip> UpdateScholarShipStatus(Guid scholarshipId,Scholarhip updatedS,Guid UserId);
        Task<Scholarhip> Add(Scholarhip scholarhip,Guid UserId);
    }
}