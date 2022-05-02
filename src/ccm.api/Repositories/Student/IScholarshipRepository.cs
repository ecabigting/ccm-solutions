using System;
using ccm.entities.Entities.Student;

namespace ccm.api.Repositories.Student
{
    public interface IScholarshipRepository
    {
        Task<List<Scholarship>> GetAll();
        Task<List<Scholarship>> GetAllEnabled();
        Task<Scholarship> GetById(Guid Id);
        Task<Scholarship> UpdateScholarShip(Guid scholarshipId,Scholarship Scholarhip,Guid UserId);
        Task<Scholarship> UpdateScholarShipStatus(Guid scholarshipId,Scholarship updatedS,Guid UserId);
        Task<Scholarship> Add(Scholarship Scholarhip,Guid UserId);
    }
}