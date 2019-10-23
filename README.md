# Migrations & Database:
	1) To add migration, go to the solution directory and type: `dotnet ef migrations add MigrationName --project Capri.Database --startup-project Capri.Web`
	2) To remove migrations, go to the solution directory and type: `dotnet ef migrations remove --project Capri.Database --startup-project Capri.Web`
	3) To update database, go to the solution directory and type `dotnet ef database update --project Capri.Database --startup-project Capri.Web`