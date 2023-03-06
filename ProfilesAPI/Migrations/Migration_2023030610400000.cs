using FluentMigrator;

namespace ProfilesAPI.Migrations;

[Migration(2023030610400000)]
public class Migration_2023030610400000 : Migration
{
    public override void Down()
    {
        Delete.Table("Accounts");
    }

    public override void Up()
    {
        Create.Table("Accounts")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Email").AsString().NotNullable()
            .WithColumn("Password").AsString().NotNullable()
            .WithColumn("PhoneNumber").AsString().NotNullable()
            .WithColumn("IsEmailVerified").AsBoolean().NotNullable()
            .WithColumn("PhotoId").AsGuid().NotNullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable()
            .WithColumn("UpdatedAt").AsDateTime().Nullable();
    }
}