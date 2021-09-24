using ModuleServicePOS.Data;
using ModuleServicePOS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public class UserService : IUserService
    {
        private IRepository<UserDetail> _userRepository;

        public UserService(IRepository<UserDetail> userRepository)
        {
            _userRepository = userRepository;
        }
        public void DeleteUser(long id)
        {
            UserDetail user = GetUser(id);
            _userRepository.Remove(user);
            _userRepository.SaveChanges();
        }

        public UserDetail GetUser(long id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<UserDetail> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public void InsertUser(UserDetail user)
        {
            _userRepository.Insert(user);
        }

        public void UpdateUser(UserDetail user)
        {
            _userRepository.Update(user);
        }
    }
}
