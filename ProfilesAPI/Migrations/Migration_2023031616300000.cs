using FluentMigrator;

namespace ProfilesAPI.Migrations;

[Migration(2023031618300000)]
public class Migration_2023031618300000 : Migration
{
    public override void Down()
    {
        //Delete.Column("MiddleName").FromTable("Doctors");
    }
    
    public override void Up()
    {
        Alter.Table("Doctors")
            .AlterColumn("MiddleName")
            .AsString()
            .Nullable();
    }
}