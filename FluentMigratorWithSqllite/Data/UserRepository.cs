using Dapper;

namespace FluentMigrationWithSqllite.Data;

public class UserRepository
{
    private readonly SqliteDbConnectionFactory _connectionFactory = new();

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateDbConnectionAsync();
        return await connection.QueryAsync<User>("select * from Users");
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        const string query = "select * from Users where Id = @Id";
        using var connection = await _connectionFactory.CreateDbConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<User>(query, new { Id = id });
    }

    public async Task<bool> CreateAsync(User user)
    {
        const string query = "INSERT INTO Users (FullName) VALUES (@FullName)";
        using var connection = await _connectionFactory.CreateDbConnectionAsync();
        var result = await connection.ExecuteAsync(query, new { user.FullName });
        return result > 0;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        const string query = "DELETE FROM Users where Id = @Id";
        using var connection = await _connectionFactory.CreateDbConnectionAsync();
        var result = await connection.ExecuteAsync(query, new { Id = id });
        return result > 0;
    }
}
