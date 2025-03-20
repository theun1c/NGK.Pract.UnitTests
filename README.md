# UserManagementDLL.UnitTests

## Описание модуля
Модуль `UserManagementDLL.UnitTests` содержит юнит-тесты для библиотеки `UserManegementDLL`, которая реализует функционал управления пользователями. Тесты написаны с использованием фреймворка NUnit и проверяют корректность работы методов класса `UserManagement`.

## Основная функциональность
Тесты покрывают следующие функции:
1. **Регистрация пользователя**:
   - Проверка успешной регистрации.
   - Обработка ошибок (например, дублирование email).

2. **Удаление пользователя**:
   - Удаление пользователя по идентификатору.

3. **Обновление данных пользователя**:
   - Обновление имени, email, пароля и роли.

4. **Получение информации о пользователе**:
   - Получение данных пользователя по его идентификатору.

5. **Аутентификация пользователя**:
   - Проверка аутентификации по email и паролю.

6. **Сброс пароля**:
   - Смена пароля пользователя.

7. **Получение списка пользователей**:
   - Получение всех пользователей.
   - Фильтрация пользователей по роли.

8. **Проверка существования пользователя**:
   - Проверка наличия пользователя по email.

9. **Получение количества пользователей**:
   - Получение общего числа зарегистрированных пользователей.

## Примеры использования
1. **Тестирование регистрации пользователя**:
   ```charp
   [Test]
   public void Registration_WhenGivenUser_ReturnsTrue()
   {
       var user = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };
       var result = _userManegement.Registration(user);
       Assert.That(result, Is.EqualTo(true));
   }
2. **Тестирование сброса пароля**:
    ```charp
    [Test]
    public void PasswordReset_WhenGivenUserAndNewPassword_ReturnsSuccessMessage()
    {
        var user = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };
        _userManegement.Registration(user);
        var result = _userManegement.PasswordReset(user, "newpassword123");
        Assert.AreEqual("Password has been changed: newpassword123", result);
    }
3. **Тестирование удаления пользователя**:
    ```charp
    [Test]
    public void Delete_WhenGivenUserId_ReturnsNull()
    {
        var user = new User { Id = 1, Email = "test@test.com", Name = "Dima", Password = "qwerty123", Role = "admin" };
        _userManegement.Registration(user);
        _userManegement.Delete(1);
        var result = _userManegement.GetUserById(1);
        Assert.IsNull(result);
    }
