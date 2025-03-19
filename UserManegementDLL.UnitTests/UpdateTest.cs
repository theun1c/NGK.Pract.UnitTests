using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    public class UpdateTest
    {
        private UserManagement _userManegement;

        [SetUp]
        public void Setup()
        {
            _userManegement = new UserManagement();
        }

        [Test]
        public void Update_WhenGivenUserAndId_ReturnsTrue()
        {
            // Arrange
            var _oldUser = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };
            _userManegement.Registration(_oldUser);
            var _userToUpdate = new User { Id = 1, Email = "test@example.com", Name = "Vova", Password = "qwerty123", Role = "user" };

            // Action
            var result = _userManegement.Update(1, _userToUpdate);
            var _updatedUser = _userManegement.GetUserById(1);

            // Assert
            Assert.That(result, Is.EqualTo(true));
            Assert.AreEqual("user", _updatedUser.Role);
            Assert.AreEqual("test@example.com", _updatedUser.Email);
            Assert.AreEqual("Vova", _updatedUser.Name);
        }

        [TearDown]
        public void TearDown()
        {
            _userManegement = null;
        }
    }
}
