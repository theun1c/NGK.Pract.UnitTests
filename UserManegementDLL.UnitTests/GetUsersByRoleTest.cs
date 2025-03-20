using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    /// <summary>
    /// Класс для тестирования функционала получения пользователей по роли
    /// </summary>
    public class GetUsersByRoleTest
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
        /// Тест для проверки получения пользователей по роли
        /// </summary>
        [Test]
        public void GetUsersByRole_WhenGivenRole_ReturnsFilteredList()
        {
            // Arrange
            var _user1 = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };
            var _user2 = new User { Id = 2, Email = "test1@test1.com", Name = "Vova", Password = "123123", Role = "admin" };
            var _user3 = new User { Id = 3, Email = "test2@test2.com", Name = "Egor", Password = "123456", Role = "user" };
            string role = "admin"; // Роль для фильтрации
            var filteredList = new List<User>(); // Ожидаемый список пользователей с ролью "admin"
            filteredList.Add(_user1);
            filteredList.Add(_user2);

            // Action
            _userManegement.Registration(_user1); // Регистрируем первого пользователя
            _userManegement.Registration(_user2); // Регистрируем второго пользователя
            _userManegement.Registration(_user3); // Регистрируем третьего пользователя
            var result = _userManegement.GetUsersByRole(role); // Получаем список пользователей по роли

            // Assert
            Assert.AreEqual(filteredList, result); // Проверяем, что возвращенный список совпадает с ожидаемым
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