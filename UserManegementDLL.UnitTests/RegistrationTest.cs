using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    public class RegistrationTest
    {
        private UserManagement _userManegement;

        [SetUp]
        public void Setup()
        {
            _userManegement = new UserManagement();
        }

        [Test]
        public void Registration_WhenGivenUser_ReturnsTrue()
        {
            // Arrange
            var _user = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password="qwerty123", Role="admin" };

            // Action
            var result = _userManegement.Registration(_user);

            // Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [TearDown]
        public void TearDown()
        {
            _userManegement = null;
        }
      
    }
}