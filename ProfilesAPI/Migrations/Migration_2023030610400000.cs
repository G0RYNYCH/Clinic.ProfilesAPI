using FluentMigrator;

namespace ProfilesAPI.Migrations;

[Migration(2023030717400000)]
public class Migration_2023030717400000 : Migration
{
    public override void Down()
    {
        
    }

    public override void Up()
    {
        Create.Table("Specializations")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("SpecializationName").AsString().NotNullable()
            .WithColumn("IsActive").AsBoolean().NotNullable();
        
        Create.Table("Doctors")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("AccountId").AsGuid().Nullable()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("MiddleName").AsString().NotNullable() //TODO: can be null
            .WithColumn("DateOfBirth").AsDate().NotNullable()
            .WithColumn("SpeciallizationId").AsGuid().NotNullable().ForeignKey("Specializations", "Id")
            .WithColumn("OfficeId").AsGuid().Nullable()
            .WithColumn("CareerStartYear").AsInt32().NotNullable()
            .WithColumn("Status").AsString().NotNullable();

        Create.Table("Patients")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("AccountId").AsGuid().Nullable()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("MiddleName").AsString().NotNullable()
            .WithColumn("DateOfBirth").AsDate().NotNullable()
            .WithColumn("IsLinkedToAccount").AsBoolean().NotNullable();

        Create.Table("Receptionists")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("AccountId").AsGuid().Nullable()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("MiddleName").AsString().NotNullable()
            .WithColumn("OfficeId").AsGuid().Nullable();
    }
}