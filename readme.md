.Net Core 2.0 SQLite example
============================

Create new console based project

     mkdir dot-net-core-sqlite
     cd dot-net-core-sqlite
     dotnet new console

Add Entity Framework (EF) Core providers

    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    dotnet add package Microsoft.EntityFrameworkCore.Design

Manually append Microsoft.EntityFrameworkCore.Tools.DotNet to DotNetCliToolReference in dot-net-core-sqlite.csproj file

    <ItemGroup>
      <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />
    </ItemGroup>

Download dependencies

    dotnet restore

(Optional) Build the append

    dotnet Build

Run it

    dotnet run
