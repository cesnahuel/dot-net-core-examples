# Protobuf Example #

This is a simple project to illustrate the brotobuf usage with c# .net core framework.

## Package ##

Add the Brotobuf package to the project's dependencies

    dotnet add package Google.Protobuf --version 3.4.0

## `protoc` compiler ##

Take the latest stable release suitable for your system from [protobuf releases](https://github.com/google/protobuf/releases) and follow the installation guide.

Gererate c# code based on the `.proto` file

    protoc --proto_path=Protobuf --csharp_out=Protobuf AddressBook.proto
