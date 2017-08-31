# NetMQ Hello World exmple with separate proceses #

Create solution to organize multiple projects

    dotnet new sln -o netmq-hello-world-separate-processes
    cd netmq-hello-world-separate-processes

Afterwards, create two projects and an additional library

    dotnet new console -o server
    dotnet sln add server/server.csproj

    dotnet new console -o client
    dotnet sln add client/client.csproj

    dotnet new classlib -o message
    dotnet sln add message/message.csproj

Add reference of the library to both projects `client` and `server`

    cd <PROJECT>
    dotnet add reference ../message/message.csproj
