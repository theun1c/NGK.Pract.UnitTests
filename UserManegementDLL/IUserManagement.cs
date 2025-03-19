using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManegementDLL
{
    public interface IUserManagement
    {
        bool Registration(User user);
        bool Delete(User user);
        bool Update(User user);
        User GetInfoById(int id);
        bool IsExistByEmail(string email);
        List<User> GetAll();
        bool Auth(string email, string password);
        bool PasswordReset(User user, string newPassword);
        int GetUsersCount();
        List<User> GetUsersByRole(string role);
    }
}
