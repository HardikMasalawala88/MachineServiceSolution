using ModuleServicePOS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public interface IUserService
    {
        IEnumerable<UserDetail> GetUsers();
        UserDetail GetUser(long id);
        void InsertUser(UserDetail user);
        void UpdateUser(UserDetail user);
        void DeleteUser(long id);
    }
}
