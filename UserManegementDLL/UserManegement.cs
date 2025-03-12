using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//TODO доделать функционал весь
namespace UserManegementDLL
{
    public class UserManegement : IUserManegement
    {
        private List<User> _users = new List<User>();

        public bool Auth(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User user)
        {
            if (user == null) 
                return false;
            else 
                _users.Remove(user);
            return true;
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetInfoById(int id)
        {
            throw new NotImplementedException();
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

        public bool Registration(User user)
        {
            if(user == null || user.Email == null || user.Password == null)
                return false;
            else
                _users.Add(user);            
            return true;
        }

        public bool Update(User user)
        {
            if (user != null || _users.Contains(user))
                return true;
            _users.Add(user);
            return false;
        }
    }
}
