using System;

namespace ccm.entities.DTOs.User
{
    public class UserAccessTokenDTO
    {
        public string Token { get; set; }
        public Guid RefreshToken { get; set; }
        public DateTimeOffset TokenExp { get; set; }
        public DateTimeOffset RefreshTokenExp { get; set; }
        public Guid UserId {get;set;}
    }
}