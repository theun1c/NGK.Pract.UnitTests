namespace UserManegementDLL.UnitTests
{
    public class Tests
    {
        private UserManegement _userManegement;
        private User _user;

        [SetUp]
        public void Setup()
        {
            _userManegement = new UserManegement();
            _user = new User();
        }

        [Test]
        public void Registration_WhenGivenUser_ReturnsTrue()
        {
            _user.Id = 1;
            _user.Name = "TestName";
            _user.Email = "TestEmail";
            _user.Password = "TestPassword";
            _user.Role = "TestRole";

            var result = _userManegement.Registration(_user);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void Delete_WhenGivenUser_ReturnsTrue()
        {
            _user.Id = 1;
            _user.Name = "TestName";
            _user.Email = "TestEmail";
            _user.Password = "TestPassword";
            _user.Role = "TestRole";

            var result = _userManegement.Delete(_user);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void Update_WhenGivenUser_ReturnsTrue()
        {
            _user.Id = 1;
            _user.Name = "TestName";
            _user.Email = "TestEmail";
            _user.Password = "TestPassword";
            _user.Role = "TestRole";

            var result = _userManegement.Update(_user);

            Assert.That(result, Is.EqualTo(true));
        }
    }
}