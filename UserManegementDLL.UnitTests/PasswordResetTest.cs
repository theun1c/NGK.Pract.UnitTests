using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    /// <summary>
    /// Класс для тестирования функционала сброса пароля пользователя
    /// </summary>
    public class PasswordResetTest
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
        /// Тест для проверки сброса пароля пользователя
        /// </summary>
        [Test]
        public void Registration_WhenGivenUser_ReturnsTrue()
        {
            // Arrange
            var _user = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };
            string newPassword = "123456"; // Новый пароль

            // Action
            var result = _userManegement.PasswordReset(_user, newPassword); // Сбрасываем пароль пользователя

            // Assert
            Assert.AreEqual("Password has been changed: 123456", result); // Проверяем, что пароль успешно изменен
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