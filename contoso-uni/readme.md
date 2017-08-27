# Configuration

During development reference the `ASPNETCORE_ENVIRONMENT` environment variable:

    env ASPNETCORE_ENVIRONMENT='Development' dotnet watch run

# Scaffold the Controller

Make sure the you add the code generation package i.e.

    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design


    dotnet restore
    dotnet aspnet-codegenerator controller -name StudentController -m Student -dc SchoolContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
