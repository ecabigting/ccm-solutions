using BCryptNet = BCrypt.Net.BCrypt;
using ccm.api.Settings;
using ccm.entities.Entities;
using ccm.entities.SpecialEntities;
using MongoDB.Driver;
using System.Text.Json;
using System.ComponentModel;
using ccm.entities.Entities.User;
using ccm.entities.Entities.Student;

namespace ccm.api.Helper
{
    public class DBSeeder : IDisposable
    {
        private ApiSettings Settings;
        private readonly IMongoCollection<Administrator> administratorCollection;
        private readonly IMongoCollection<User> userCollection;
        private readonly IMongoCollection<UserType> userTypesCollection;
        private readonly IMongoCollection<StudentScholarship> scholarshipCollection;
        private readonly IMongoCollection<StudentShift> studentshiftCollection;
        List<string> SysAds = new List<string>();        
        private readonly FilterDefinitionBuilder<Administrator> administratorFilterBuilder = Builders<Administrator>.Filter;
        private readonly FilterDefinitionBuilder<User> userFilterBuilder = Builders<User>.Filter;
        private readonly FilterDefinitionBuilder<UserType> userTypeFilterBuilder = Builders<UserType>.Filter;
        public DBSeeder(IMongoClient _mongoClient,DBSettings _dbSettings,ApiSettings _apiSettings)
        {
            IMongoDatabase db = _mongoClient.GetDatabase(_dbSettings.DbName);
            administratorCollection = db.GetCollection<Administrator>("Administrator"); 
            userCollection  = db.GetCollection<User>("User"); 
            userTypesCollection = db.GetCollection<UserType>("UserType"); 
            scholarshipCollection = db.GetCollection<StudentScholarship>("StudentScholarship"); 
            studentshiftCollection = db.GetCollection<StudentShift>("StudentShift"); 
            Settings = _apiSettings;
            using(StreamReader r = new StreamReader("sysad.json"))
            {
                string json = r.ReadToEnd();
                SysAds = JsonSerializer.Deserialize<List<string>>(json);
            }
        }
        public string BuildInitKey(string name)
        {
            return DateTimeOffset.Now.ToString("MMMM").ToLower().Replace('a','@').Replace('i','!').Replace('e','3').Replace('o','0').Replace('t','+') + name + DateTimeOffset.Now.ToString("dd");
        }
        public async void SetupStudenShifts()
        {
            var foundStudentshift = await studentshiftCollection.Find(x => true).FirstOrDefaultAsync();
            if(foundStudentshift == null)
            {
                DateTimeOffset dtNow = DateTimeOffset.Now;
                var foundAdministrator = await administratorCollection.Find(x => true).FirstOrDefaultAsync();
                List<StudentShift> studentShifts = new List<StudentShift>{
                    new StudentShift{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime =dtNow,
                        Description = "Morning",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Morning",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = dtNow
                    },
                    new StudentShift{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime =dtNow,
                        Description = "Afternoon",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Afternoon",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = dtNow
                    },
                    new StudentShift{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime =dtNow,
                        Description = "Evening",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Evening",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = dtNow
                    }
                };
                await studentshiftCollection.InsertManyAsync(studentShifts);
            }
        }
        public async void SetupScholarships()
        {
            var foundScholarships = await scholarshipCollection.Find(x => true).FirstOrDefaultAsync();
            if(foundScholarships == null)
            {
                DateTimeOffset dtNow = DateTimeOffset.Now;
                var foundAdministrator = await administratorCollection.Find(x => true).FirstOrDefaultAsync();
                List<StudentScholarship> scholarships = new List<StudentScholarship>{
                    new StudentScholarship{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime =dtNow,
                        Description = "LEA",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "LEA",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = dtNow
                    },
                    new StudentScholarship{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime =dtNow,
                        Description = "B641",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "B641",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = dtNow
                    },
                    new StudentScholarship{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime =dtNow,
                        Description = "Alumni",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Alumni",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = dtNow
                    },
                    new StudentScholarship{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime =dtNow,
                        Description = "New Day",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "New Day",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = dtNow
                    },
                };
                await scholarshipCollection.InsertManyAsync(scholarships);
            }
        }
        public async void SetupUserTypes()
        {
            var foundUserTypes = await userTypesCollection.Find(x => true).FirstOrDefaultAsync();
            if(foundUserTypes == null)
            {
                var foundAdministrator = await administratorCollection.Find(x => true).FirstOrDefaultAsync();
                List<UserType> uTypes = new List<UserType>{
                    new UserType{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime = DateTimeOffset.UtcNow,
                        Description = "Admin has full system access",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Admin",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = DateTimeOffset.UtcNow
                    },
                    new UserType{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime = DateTimeOffset.UtcNow,
                        Description = "Student has access to courses and classes",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Student",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = DateTimeOffset.UtcNow
                    },
                    new UserType{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime = DateTimeOffset.UtcNow,
                        Description = "Teachers has full courses, classes and students",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Teachers",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = DateTimeOffset.UtcNow,
                    },
                    new UserType{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime = DateTimeOffset.UtcNow,
                        Description = "Admin has access to courses, classes, teachers, and students",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Dean",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = DateTimeOffset.UtcNow
                    },
                    new UserType{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime = DateTimeOffset.UtcNow,
                        Description = "Finance Director",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Has access to student records, teacher records, class prices, accounting",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = DateTimeOffset.UtcNow
                    },
                    new UserType{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime = DateTimeOffset.UtcNow,
                        Description = "Accountant",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Has access to student records,Payroll, teacher records, class prices, accounting",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = DateTimeOffset.UtcNow
                    },
                    new UserType{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime = DateTimeOffset.UtcNow,
                        Description = "Accounting Clerk",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Has access to student records, teacher records, class prices, accounting",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = DateTimeOffset.UtcNow
                    },
                    new UserType{
                        CreatedBy = foundAdministrator.Id,
                        CreatedDateTime = DateTimeOffset.UtcNow,
                        Description = "Finance Director",
                        IsEnabled = true,
                        IsEnabledBy = foundAdministrator.Id,
                        Name = "Has access to student records, teacher records, class prices, accounting",
                        UpdatedBy = foundAdministrator.Id,
                        UpdatedDateTime = DateTimeOffset.UtcNow
                    },
                };
                await userTypesCollection.InsertManyAsync(uTypes);
            }
        }
        public async void SetupSystemAdmin()
        {
            string Gname = SysAds.OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault();
            var foundAdministrator = await administratorCollection.Find(x => true).FirstOrDefaultAsync();
            if(foundAdministrator == null)
            {
                Guid GodID = Guid.NewGuid();
                Administrator GodAdmin = new Administrator {
                    Id = GodID,
                    CreatedBy = GodID,
                    Email = "",
                    IsEnabled = true,
                    IsEnabledBy = GodID,
                    Password = BCryptNet.HashPassword(BuildInitKey(Gname)),
                    CreatedDateTime = DateTimeOffset.UtcNow,
                    UpdatedDateTime = DateTimeOffset.UtcNow,
                    Username = Gname,
                    UpdatedBy = GodID,
                    PasswordExpirationDate = DateTimeOffset.UtcNow.AddDays(30)
                };
                await administratorCollection.InsertOneAsync(GodAdmin);
            }          
        }

        /*
        *
        * Disposing the DBSeeder resource
        * Read here: https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?redirectedfrom=MSDN&view=net-6.0
        *
        */
        // Other managed resource this class uses.
        private Component component = new Component();
        // Track whether Dispose has been called.
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    component.Dispose();
                }
                disposed = true;
            }
        }
        ~DBSeeder()
        {
            Dispose(disposing: false);
        }
    }
}