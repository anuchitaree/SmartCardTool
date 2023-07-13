HVAC Database IP

<add name="AppDatabaseConnectionString"
			 connectionString="Server=192.168.80.60;Port=5432;Database=smartcard;User Id=postgres;Password=admin"
			 providerName="Npgsql" />




EntityFramework 6.4.4
EntityFramework6.Npgsql 6.4.3


Enable-Migrations –EnableAutomaticMigration:$true


Add-Migration Initial1

Update-Database



<add name="Default" connectionString="host=localhost;user id=postgres;password=admin;database=workingStandard;Pooling=false;Timeout=300;CommandTimeout=300;" providerName="Npgsql" />