using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    /// <summary>
    /// Класс для тестирования функционала получения количества пользователей
    /// </summary>
    public class GetUsersCountTest
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
        /// Тест для проверки получения количества пользователей
        /// </summary>
        [Test]
        public void GetUsersCount_WhenСallingTheMethod_ReturnsUsersList()
        {
            // Arrange
            var _user1 = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };
            var _user2 = new User { Id = 2, Email = "test1@test1.com", Name = "Vova", Password = "123456", Role = "admin" };

            // Action
            _userManegement.Registration(_user1); // Регистрируем первого пользователя
            _userManegement.Registration(_user2); // Регистрируем второго пользователя
            var result = _userManegement.GetUsersCount(); // Получаем количество пользователей

            // Assert
            Assert.AreEqual(2, result); // Проверяем, что количество пользователей равно 2
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