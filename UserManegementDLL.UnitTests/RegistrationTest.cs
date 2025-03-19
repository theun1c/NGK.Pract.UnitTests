namespace UserManegementDLL.UnitTests
{
    public class Tests
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
            var _user = new User();

            _user.Id = 1;
            _user.Name = "TestName";
            _user.Email = "TestEmail";
            _user.Password = "TestPassword";
            _user.Role = "TestRole";

            var result = _userManegement.Registration(_user);

            Assert.That(result, Is.EqualTo(true));
        }
      
    }
}