using System;
using ccm.entities.Entities.User;

namespace ccm.api.Repositories.User
{
    public interface IUserRepository
    {
        Task<UserType> GetEnabledUserTypes();
        Task<bool> DoesUserEmailExist();

    }
}