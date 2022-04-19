using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccm.api.Helper
{
    public interface IDBSeeder
    {
        bool DoWeHaveAnAdministrator();
        bool DoWeHaveAnAdmin();
        void SetupUserTypes();
    }
}