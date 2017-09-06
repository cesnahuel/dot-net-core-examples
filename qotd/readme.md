# .NET Core 2.0 on Raspberry PI #

Sad news first: There is **no SDK** available as of .NET Core 2.0 for the **armhf** architecture.
This implies that it's not possible to develop and compile code on Rasperry PI at the moment.

## Install the .NET Core Runtime on the Raspberry PI ##

Install dependencies for the .NET core Runtime

    sudo apt-get install curl libunwind8 gettext

Download the latest `dotnet-runtime-latest-linux-arm.tar.gz` archive file by

    curl --location https://dotnetcli.blob.core.windows.net/dotnet/Runtime/release/2.0.0/dotnet-runtime-latest-linux-arm.tar.gz

Extract its content into `/opt/dotnet` directory

    sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz  -C /opt/dotnet

Create symlink in `/usr/local/bin`

    sudo ln -s /opt/dotnet/dotnet /usr/local/bin

Finally, test that it works as desired

    dotnet --info

    Microsoft .NET Core Shared Framework Host

    Version  : 2.0.1-servicing-25630-01
    Build    : 6121f9d0e6ede2b509f1003f97ad3758ed981785

## Build your project elsewhere ##

This description is based on the `dotd` project as example. Therefore

    cd dotd
    dotnet publish -r linux-arm

This creates a self contained build in the folder `./bin/Debug/netcoreapp2.0/linux-arm/publish/` suitable for execution on Raspian.

## Execute the self contained build on Raspbian ##

Transfer the application's files to the Raspberry PI and run it

    scp -r ./bin/Debug/netcoreapp2.0/linux-arm/publish/* ibqn@rp3:devel/qotd/
    ibqn@pi3 ~/devel/qotd $ ./qotd quotes.txt
