using System;
using ccm.entities.Entities.Student;

namespace ccm.api.Repositories.Student
{
    public interface IScholarshipRepository
    {
        Task<List<StudentScholarship>> GetAll();
        Task<List<StudentScholarship>> GetAllEnabled();
        Task<StudentScholarship> GetById(Guid Id);
        Task<StudentScholarship> UpdateScholarShip(Guid scholarshipId,StudentScholarship Scholarhip,Guid UserId);
        Task<StudentScholarship> UpdateScholarShipStatus(Guid scholarshipId,StudentScholarship updatedS,Guid UserId);
        Task<StudentScholarship> Add(StudentScholarship Scholarhip,Guid UserId);
    }
}