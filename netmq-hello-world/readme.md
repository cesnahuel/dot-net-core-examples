# NetMQ example #

add NetMQ package to the project

    dotnet add package NetMQ --version 4.0.0.1

read the traffic from `lo` using the `ngrep` tool

    sudo ngrep -d lo '' 'port 52298'

or with `tcptump`

    sudo tcpdump -i lo -n "port 5556"
