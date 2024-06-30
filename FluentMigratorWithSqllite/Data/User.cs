namespace FluentMigrationWithSqllite.Data;

public class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = default!;
}
