# SWGlobalTest

The Project users PostgreSQL as the database.

After the code is pulled, edit app config to customise DB connection string then run migration with the code below in Package Manager Console.

PM> Add-Migration InitialMigration
PM> Update-Database

The initialMigration seeds an admin account. UserName is "admin@gmail.com" and password is "administrator"
