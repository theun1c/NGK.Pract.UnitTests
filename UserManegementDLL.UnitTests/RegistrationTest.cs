using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManegementDLL;

namespace UserManagementDLL.UnitTests
{
    /// <summary>
    /// ����� ��� ������������ ����������� ����������� ������������
    /// </summary>
    public class RegistrationTest
    {
        private UserManagement _userManegement;

        /// <summary>
        /// �����, ������� ����������� ����� ������ ������
        /// �������������� ������ UserManagement
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _userManegement = new UserManagement();
        }

        /// <summary>
        /// ���� ��� �������� �������� ����������� ������������
        /// </summary>
        [Test]
        public void Registration_WhenGivenUser_ReturnsTrue()
        {
            // Arrange
            var _user = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };

            // Action
            var result = _userManegement.Registration(_user); // ������������ ������������

            // Assert
            Assert.That(result, Is.EqualTo(true)); // ���������, ��� ����������� ������ �������
        }

        /// <summary>
        /// �����, ������� ����������� ����� ������� �����
        /// ����������� �������, ������� ������ UserManagement
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _userManegement = null;
        }
    }
}