Installation Instructions 

1. This solution will run on Visual Studio 2019. Please download visual studio 2019 Community Edition from https://visualstudio.microsoft.com/downloads/

2.Install .Net Core 3.1 SDK from https://dotnet.microsoft.com/download/dotnet-core/3.1

3. Right Click on TodoItems.Database and publish the database. Database should be published successfully.

4. Update ConnectionString in appsettings.json in TodoItems.Api

5. Run backend application by F5 or by clicking on debug. This should run backend on port 50206

6. open ui\TodoItemUi in visual studio code.

7. Run command "npm install" in terminal to install missing packages

8. If backend application is not running on port 50206 then update new port in environment.ts file.

9. Run command "ng serve -o" to run front end application. 

