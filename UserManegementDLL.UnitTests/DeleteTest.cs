using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    /// <summary>
    /// Класс для тестирования функционала удаления пользователя.
    /// </summary>
    public class DeleteTest
    {
        private UserManagement _userManegement;

        /// <summary>
        /// Метод, который выполняется перед каждым тестом.
        /// Инициализирует объект UserManagement.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _userManegement = new UserManagement();
        }

        /// <summary>
        /// Тест для проверки удаления пользователя по его идентификатору.
        /// </summary>
        [Test]
        public void Delete_WhenGivenUserId_ReturnsNull()
        {
            // Arrange
            var _user = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };

            // Action
            _userManegement.Registration(_user); // Регистрируем пользователя
            _userManegement.Delete(1); // Удаляем пользователя по Id

            var result = _userManegement.GetUserById(1); // Пытаемся получить удаленного пользователя

            // Assert
            Assert.IsNull(result); // Проверяем, что пользователь удален (результат равен null)
        }

        /// <summary>
        /// Метод, который выполняется после каждого теста.
        /// Освобождает ресурсы, обнуляя объект UserManagement.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _userManegement = null;
        }
    }
}