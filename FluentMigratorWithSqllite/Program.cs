using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrationWithSqllite.Data;
using FluentMigrationWithSqllite.Migrations;
using Bogus;

using ServiceProvider serviceProvider = CreateServices();
using IServiceScope scope = serviceProvider.CreateScope();
UpdateDatabase(scope.ServiceProvider);

UserService userService = new();

Console.WriteLine("Create new user? Please enter yes or no.");

string? createUser = Console.ReadLine();

if (createUser == "yes")
{
    Faker faker = new Faker();

    Console.WriteLine("Please enter the count how many record you would to create:");

    bool canParsed = int.TryParse(Console.ReadLine(), out int count);

    if(!canParsed)
    {
        Console.WriteLine("Invalid input");
        return;
    }

    for (int i = 0; i < count; i++)
    {
        await userService.CreateAsync(new User { FullName = faker.Name.FullName() });
    }
}

IEnumerable<User> users = await userService.GetAllAsync();

foreach (User user in users)
{
    Console.WriteLine($"{user.Id} {user.FullName}");
}


/// <summary>
/// Configure the dependency injection services
/// </summary>
static ServiceProvider CreateServices()
{
    return new ServiceCollection()
        // Add common FluentMigrator services
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            // Add SQLite support to FluentMigrator
            .AddSQLite()
            // Set the connection string
            .WithGlobalConnectionString("Data Source=./database.db")
            // Define the assembly containing the migrations
            .ScanIn(typeof(CreateUsersTable).Assembly).For.Migrations())
        // Enable logging to console in the FluentMigrator way
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        // Build the service provider
        .BuildServiceProvider(false);
}

/// <summary>
/// Update the database
/// </summary>
static void UpdateDatabase(IServiceProvider serviceProvider)
{
    // Instantiate the runner
    IMigrationRunner runner = serviceProvider.GetRequiredService<IMigrationRunner>();

    // Execute the migrations
    runner.MigrateUp();
}

Console.WriteLine("\nDone");