using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccm.api.Settings
{
    public class ApiSettings
    {
        public string HashKey { get; set; }
        public string Issuer { get; set; }
        public string Audience {get;set;}
        public string JWTKey { get; set; }
        public int TokenExp { get; set; }
        public int RefreshTokenExp { get; set; }
    }
}