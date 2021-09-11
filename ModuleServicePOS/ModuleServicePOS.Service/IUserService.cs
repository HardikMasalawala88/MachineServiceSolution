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
        IEnumerable<UserDetails> GetUsers();
        UserDetails GetUser(long id);
        void InsertUser(UserDetails user);
        void UpdateUser(UserDetails user);
        void DeleteUser(long id);
    }
}
