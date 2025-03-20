using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    /// <summary>
    /// Класс для тестирования функционала обновления данных пользователя
    /// </summary>
    public class UpdateTest
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
        /// Тест для проверки обновления данных пользователя
        /// </summary>
        [Test]
        public void Update_WhenGivenUserAndId_ReturnsTrue()
        {
            // Arrange
            var _oldUser = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };
            _userManegement.Registration(_oldUser); // Регистрируем старого пользователя
            var _userToUpdate = new User { Id = 1, Email = "test@example.com", Name = "Vova", Password = "qwerty123", Role = "user" }; // Новые данные для обновления

            // Action
            var result = _userManegement.Update(1, _userToUpdate); // Обновляем данные пользователя
            var _updatedUser = _userManegement.GetUserById(1); // Получаем обновленного пользователя

            // Assert
            Assert.That(result, Is.EqualTo(true)); // Проверяем, что метод обновления вернул true
            Assert.AreEqual("user", _updatedUser.Role); // Проверяем, что роль обновлена
            Assert.AreEqual("test@example.com", _updatedUser.Email); // Проверяем, что email обновлен
            Assert.AreEqual("Vova", _updatedUser.Name); // Проверяем, что имя обновлено
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