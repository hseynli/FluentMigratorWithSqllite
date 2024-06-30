using FluentMigrationWithSqllite.Data;

namespace FluentMigratorWithSqllite.Tests.Unit;

internal class FakeUserRepository : IUserRepository
{
    private readonly Dictionary<int, User> _users = new();

    public Task<bool> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await Task.FromResult(_users.Values.AsEnumerable());
    }

    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
