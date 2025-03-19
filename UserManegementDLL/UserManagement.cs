using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//TODO доделать функционал весь
namespace UserManegementDLL
{
    public class UserManagement
    {
        private List<User> _users = new List<User>();

        public bool Registration(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user cannot be empty!");
            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentNullException("user email cannot be empty!");
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentNullException("user password cannot be empty!");
            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentNullException("user name cannot be empty!");

            if (_users.Any(u => u.Email == user.Email))
                throw new Exception("this email has already been used");

            _users.Add(user);
            return true;
        }

        public void Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public bool Update(int id, User updatedUser)
        {
            if(updatedUser == null)
                throw new ArgumentNullException("user cannot be empty!");

            var oldUser = _users.FirstOrDefault(u => u.Id == id);
            if (oldUser == null)
                throw new ArgumentNullException("user cannot be empty!");

            oldUser.Email = updatedUser.Email;
            oldUser.Password = updatedUser.Password;
            oldUser.Name = updatedUser.Name;
            oldUser.Role = updatedUser.Role;

            return true;
        }

        public bool Auth(string email, string password)
        {
            throw new NotImplementedException();
        }

       

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetUsersByRole(string role)
        {
            throw new NotImplementedException();
        }

        public int GetUsersCount()
        {
            throw new NotImplementedException();
        }

        public bool IsExistByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool PasswordReset(User user, string newPassword)
        {
            throw new NotImplementedException();
        }

        
    }
}
