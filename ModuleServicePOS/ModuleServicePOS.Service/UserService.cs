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
        private IRepository<UserDetails> _userRepository;

        public UserService(IRepository<UserDetails> userRepository)
        {
            _userRepository = userRepository;
        }
        public void DeleteUser(long id)
        {
            UserDetails user = GetUser(id);
            _userRepository.Remove(user);
            _userRepository.SaveChanges();
        }

        public UserDetails GetUser(long id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<UserDetails> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public void InsertUser(UserDetails user)
        {
            _userRepository.Insert(user);
        }

        public void UpdateUser(UserDetails user)
        {
            _userRepository.Update(user);
        }
    }
}
