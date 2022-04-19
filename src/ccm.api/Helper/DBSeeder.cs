using BCryptNet = BCrypt.Net.BCrypt;
using ccm.api.Settings;
using ccm.entities.Entities;
using ccm.entities.SpecialEntities;
using MongoDB.Driver;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ccm.api.Helper
{
    public class DBSeeder : IDBSeeder
    {
        private ApiSettings Settings;
        private readonly IMongoCollection<Administrator> administratorCollection;
        private readonly IMongoCollection<User> userCollection;
        private readonly IMongoCollection<UserTypes> userTypesCollection;
        List<string> SysAds = new List<string>();        
        private readonly FilterDefinitionBuilder<Administrator> filterBuilder = Builders<Administrator>.Filter;
        private readonly FilterDefinitionBuilder<User> userFilterBuilder = Builders<User>.Filter;
        private readonly FilterDefinitionBuilder<UserTypes> userTypeFilterBuilder = Builders<UserTypes>.Filter;
        public DBSeeder(IMongoClient _mongoClient,DBSettings _dbSettings,ApiSettings _apiSettings)
        {
            IMongoDatabase db = _mongoClient.GetDatabase(_dbSettings.DbName);
            administratorCollection = db.GetCollection<Administrator>("Administrator"); 
            userCollection  = db.GetCollection<User>("User"); 
            userTypesCollection= db.GetCollection<UserTypes>("UserTypes"); 
            Settings = _apiSettings;
            using(StreamReader r = new StreamReader("sysadd.json"))
            {
                string json = r.ReadToEnd();
                SysAds = JsonSerializer.Deserialize<List<string>>(json);
            }
        }

        public void SetupUserTypes()
        {
            // var adminUserTypeIsFound = userTypeFilterBuilder.Where(ut => ut.Name == "Admin");
            // if(adminUserTypeIsFound == null) // no admin user type, lets create one
            // {
            //     UserTypes NewAdmin = new UserTypes{
            //         CreatedBy = 
            //     };
            // }
        }

        public void SetupSystemAdmin()
        {
            Administrator GodAdmin = new Administrator {
                CreatedBy = Guid.NewGuid(),
                Email = "",
                IsEnabled = true,
                IsEnabledBy = Guid.NewGuid(),
                Password = BCryptNet.HashPassword(""),
                CreatedDateTime = DateTimeOffset.UtcNow,
                UpdatedDateTime = DateTimeOffset.UtcNow,
                Username = SysAds.OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault(),
                UpdatedBy = Guid.NewGuid()
            };
        }

        public bool DoWeHaveAnAdministrator()
        {
            return false;
        }

        public bool DoWeHaveAnAdmin()
        {
            return false;
        }
    }
}