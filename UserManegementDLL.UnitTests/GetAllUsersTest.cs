using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    /// <summary>
    /// Класс для тестирования функционала получения списка всех пользователей
    /// </summary>
    internal class GetAllUsersTest
    {
        private UserManagement _userManegement;

        /// <summary>
        /// Метод, который выполняется перед каждым тестом
        /// Инициализирует объект UserManagement
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _userManegement = new UserManagement();
        }

        /// <summary>
        /// Тест для проверки получения списка всех пользователей
        /// </summary>
        [Test]
        public void GetAllUsers_WhenСallingTheMethod_ReturnsUsersList()
        {
            // Arrange
            var _user1 = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };
            var _user2 = new User { Id = 2, Email = "test1@test1.com", Name = "Vova", Password = "123456", Role = "admin" };
            var usersList = new List<User>();
            usersList.Add(_user1);
            usersList.Add(_user2);

            // Action
            _userManegement.Registration(_user1); // Регистрируем первого пользователя
            _userManegement.Registration(_user2); // Регистрируем второго пользователя
            var result = _userManegement.GetAllUsers(); // Получаем список всех пользователей

            // Assert
            Assert.AreEqual(usersList, result); // Проверяем, что список пользователей совпадает с ожидаемым
        }

        /// <summary>
        /// Метод, который выполняется после каждого теста
        /// Освобождает ресурсы, обнуляя объект UserManagement
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _userManegement = null;
        }
    }
}