using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    /// <summary>
    /// Класс для тестирования функционала получения информации о пользователе по его идентификатору
    /// </summary>
    public class GetInfoByIdTest
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
        /// Тест для проверки получения информации о пользователе по его Id
        /// </summary>
        [Test]
        public void GetUserInfoById_WhenGivenUserId_ReturnsString()
        {
            // Arrange
            var _user = new User { Id = 1, Email = "test@example.com", Name = "Vova", Password = "qwerty123", Role = "user" };

            // Action
            _userManegement.Registration(_user); // Регистрируем пользователя
            var result = _userManegement.GetUserInfoById(1); // Получаем информацию о пользователе по Id

            // Assert
            Assert.AreEqual($"Name: Vova Email: test@example.com Role: user", result); // Проверяем, что информация совпадает с ожидаемой
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