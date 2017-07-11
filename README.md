# Doglist Example App for *Win/OSX/Linux* C# Development

----
### Description

This app is an example application for use in curriculum development at Epicodus. It allows lessons to be written that will follow the C# standard of .NET Core 1.1, and build on basic OOP and RESTful routing, along with Epicodus standard SQL education.

It was built from 7-5 through 7-11 by John Franti.

----
### Dependancies

This project requires the installation of the [.NET Core 1.1 SDK](https://www.microsoft.com/net/download/core)

The SQL service in use is the [Microsoft/mssql-server-linux](https://hub.docker.com/r/microsoft/mssql-server-linux/) container for [Docker](https://www.docker.com/community-edition)


----

### SQL setup

Install Docker and the mssql container. An *excellent* guide can be found [on David Neal's blog](https://medium.com/@reverentgeek/sql-server-running-on-a-mac-3efafda48861)

When you create your container, and setup your server, use the following credentials

```
database name: doglist
User Id: sa
Password: Epic0dus
```

Once interacting with SQL database, create the following table:

```
CREATE TABLE dogs (id INT IDENTITY (1,1), name VARCHAR(255));
```

----

### Other information / bugs

placeholder

----
