using System;
using ccm.entities.Entities.User;

namespace ccm.entities.DTOs.User
{
    public class UserProfileDTO
    {
        public Entities.User.User Details {get;set;}
        public UserAccessTokenDTO TokenDTO {get;set;}
    }
}