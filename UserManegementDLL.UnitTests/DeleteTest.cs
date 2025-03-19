using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    public class DeleteTest
    {
        private UserManagement _userManegement;

        [SetUp]
        public void Setup()
        {
            _userManegement = new UserManagement();
        }

        [Test]
        public void Delete_WhenGivenUser_ReturnsNull()
        {
            // Arrange
            var _user = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };

            // Action
            _userManegement.Registration(_user);

            _userManegement.Delete(1);

            var result = _userManegement.GetUserById(1);
            // Assert
            Assert.IsNull(result);
        }

        [TearDown]
        public void TearDown()
        {
            _userManegement = null;
        }
    }
}
