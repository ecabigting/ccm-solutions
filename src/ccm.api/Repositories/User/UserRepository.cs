using System;
using ccm.entities.Entities.User;

namespace ccm.api.Repositories.User
{
    public class UserRepository : CommonRepository, IUserRepository
    {
        public Task<bool> DoesUserEmailExist()
        {
            throw new NotImplementedException();
        }

        public Task<UserType> GetEnabledUserTypes()
        {
            throw new NotImplementedException();
        }
    }
}