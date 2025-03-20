using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    /// <summary>
    /// Класс для тестирования функционала проверки существования пользователя по email
    /// </summary>
    public class IsExistByEmailTest
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
        /// Тест для проверки существования пользователя по email
        /// </summary>
        [Test]
        public void IsExistByEmail_WhenGivenEmail_ReturnsTrue()
        {
            // Arrange
            var _user = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };

            // Action
            _userManegement.Registration(_user); // Регистрируем пользователя
            var result = _userManegement.IsExistByEmail("test@test.com"); // Проверяем существование пользователя по email

            // Assert
            Assert.That(result, Is.EqualTo(true)); // Проверяем, что метод возвращает true
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