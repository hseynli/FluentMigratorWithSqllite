namespace FluentMigrationWithSqllite.Data;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<bool> CreateAsync(User user);
    Task<bool> DeleteByIdAsync(int id);
}