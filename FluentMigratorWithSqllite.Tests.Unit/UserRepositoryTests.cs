using FluentMigrationWithSqllite.Data;
using NSubstitute;

namespace FluentMigratorWithSqllite.Tests.Unit
{
    public class UserRepositoryTests
    {
        private readonly UserService _userService;
        private readonly IUserRepository _mockUserRepository  = Substitute.For<IUserRepository>();

        public UserRepositoryTests()
        {
            _userService = new UserService(_mockUserRepository);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturn_User_WhenUserExists()
        {
            // Arrange
            User user = new User() { Id = 1 };

            // Act
            User? foundUser = await _mockUserRepository.GetByIdAsync(1);

            // Assert
            foundUser.Returns(foundUser);
        }
    }
}