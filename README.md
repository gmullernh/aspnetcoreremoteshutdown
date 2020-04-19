# ASP.NET Core Remote Control
Application for remote control of a machine using .NET Core.

## About

This application implements a command pattern to enable multiple commands to be activated remotly through a web interface.

## How to use

The default implementation runs at port http://localhost:5555/controlpanel.
Run the application on the target machine and access it from another computer <http://MACHINE-IP:5555/controlpanel> to schedule shutdown or run another command immediately.
