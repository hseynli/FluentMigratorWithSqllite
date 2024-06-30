using System.Data;

namespace FluentMigrationWithSqllite.Data;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateDbConnectionAsync();
}