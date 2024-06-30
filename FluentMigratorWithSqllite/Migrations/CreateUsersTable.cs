using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentMigrationWithSqllite.Migrations
{

    [Migration(20240630, "Create the Users table")]
    public class CreateUsersTable : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("FullName").AsString();
        }

        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}
