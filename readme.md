# .Net Core 2.0 examples #

## Create new console based project ##

    mkdir dot-net-core-sqlite
    cd dot-net-core-sqlite
    dotnet new console

## Add Entity Framework (EF) Core providers ##

    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    dotnet add package Microsoft.EntityFrameworkCore.Design

EF Core includes an additional set of commands for the dotnet CLI, starting with `dotnet ef`. In order to use the `dotnet ef` CLI commands, your application’s `.csproj` file needs to contain the following entry:

    <ItemGroup>
      <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />
    </ItemGroup>

Therefore, manually append `Microsoft.EntityFrameworkCore.Tools.DotNet` to DotNetCliToolReference in `dot-net-core-sqlite.csproj` file.

## Download dependencies ##

    dotnet restore

(Optional) Build the app

    dotnet build

## Create the database ##

Run the following command to create initial Migrations

    dotnet ef migrations add InitialCreate

Apply the migration changes to the database

    dotnet ef database update

## Run it ##

From the fish shell start the project in development mode in the watch mode

    env ASPNETCORE_ENVIRONMENT='Development'  dotnet watch run
