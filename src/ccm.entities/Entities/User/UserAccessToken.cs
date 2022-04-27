using System;

namespace ccm.entities.Entities.User
{
    public class UserAccessToken : Common
    {
        public string Token { get; set; }
        public Guid RefreshToken { get; set; }
        public DateTimeOffset TokenExp { get; set; }
        public DateTimeOffset RefreshTokenExp { get; set; }
        public Guid UserId {get;set;}
    }
}