using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManegementDLL
{
    /// <summary>
    /// Класс для управления пользователями.
    /// Предоставляет функционал для регистрации, удаления, обновления и поиска пользователей.
    /// </summary>
    public class UserManagement
    {
        private List<User> _users = new List<User>();

        /// <summary>
        /// Регистрирует нового пользователя.
        /// </summary>
        /// <param name="user">Объект пользователя для регистрации.</param>
        /// <returns>Возвращает true, если регистрация прошла успешно.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если пользователь или его данные пусты.</exception>
        /// <exception cref="Exception">Выбрасывается, если email уже используется.</exception>
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

        /// <summary>
        /// Удаляет пользователя по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public void Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        /// <summary>
        /// Обновляет данные пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя для обновления.</param>
        /// <param name="updatedUser">Объект с обновленными данными пользователя.</param>
        /// <returns>Возвращает true, если обновление прошло успешно.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если пользователь или его данные пусты.</exception>
        public bool Update(int id, User updatedUser)
        {
            if (updatedUser == null)
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

        /// <summary>
        /// Возвращает информацию о пользователе по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Строка с информацией о пользователе.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если пользователь не найден.</exception>
        public string GetUserInfoById(int id)
        {
            var user = _users.FirstOrDefault(u => id == u.Id);
            if (user == null)
                throw new ArgumentNullException("user cannot be empty!");
            return $"Name: {user.Name} Email: {user.Email} Role: {user.Role}";
        }

        /// <summary>
        /// Проверяет существование пользователя по email.
        /// </summary>
        /// <param name="email">Email пользователя.</param>
        /// <returns>Возвращает true, если пользователь существует.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если пользователь не найден.</exception>
        public bool IsExistByEmail(string email)
        {
            var user = _users.FirstOrDefault(u => email == u.Email);
            if (user == null)
                throw new ArgumentNullException("user cannot be empty!");
            return true;
        }

        /// <summary>
        /// Возвращает список всех пользователей.
        /// </summary>
        /// <returns>Список пользователей.</returns>
        public List<User> GetAllUsers()
        {
            return _users;
        }

        /// <summary>
        /// Аутентифицирует пользователя по email и паролю.
        /// </summary>
        /// <param name="email">Email пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Возвращает true, если аутентификация прошла успешно.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если пользователь не найден.</exception>
        public bool UserAuth(string email, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
                throw new ArgumentNullException("user cannot be empty!");

            return true;
        }

        /// <summary>
        /// Сбрасывает пароль пользователя.
        /// </summary>
        /// <param name="user">Объект пользователя.</param>
        /// <param name="newPassword">Новый пароль.</param>
        /// <returns>Строка с подтверждением смены пароля.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если пользователь или новый пароль пусты.</exception>
        public string PasswordReset(User user, string newPassword)
        {
            if (user == null)
                throw new ArgumentNullException("user cannot be empty!");
            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentNullException("new password cannot be empty!");

            user.Password = newPassword;
            return $"Password has been changed: {user.Password}";
        }

        /// <summary>
        /// Возвращает количество зарегистрированных пользователей.
        /// </summary>
        /// <returns>Количество пользователей.</returns>
        public int GetUsersCount()
        {
            return _users.Count;
        }

        /// <summary>
        /// Возвращает список пользователей по роли.
        /// </summary>
        /// <param name="role">Роль пользователя.</param>
        /// <returns>Список пользователей с указанной ролью.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если список пользователей пуст.</exception>
        public List<User> GetUsersByRole(string role)
        {
            if (_users.Count == 0)
                throw new ArgumentNullException("users list cannot be empty!");

            var sortedUsers = _users.Where(u => u.Role == role);
            return sortedUsers.ToList();
        }

        /// <summary>
        /// Возвращает пользователя по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Объект пользователя.</returns>
        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}