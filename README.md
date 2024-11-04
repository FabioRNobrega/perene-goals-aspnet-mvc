# PERENE GOALS ASP.NET MVC | Fábio R. Nóbrega 

This project was generated with [ASP.NET Core MVC](https://learn.microsoft.com/aspnet/core) Our main go is to remake the original [Perene Goal](https://github.com/FabioRNobrega/perene-goals/tree/main) project in ASP.NET to be able to learn and apply new knowledge for this stack.

We use:
 - .NET: 6.0

Table of contents
=================

  * [Install](#install)
  * [Usage](#usage)
  * [Tests](#tests)
  * [Troubleshooting](#troubleshooting)
  * [Git Guideline](#git-guideline)

## Install

+ Clone the repo and cd into 

``` bash
$ dotnet build
```

+ For this project we are using the SQLServer for this propose you can use as docker: 

Adding the official docker image:

```bash
docker pull mcr.microsoft.com/mssql/server
```

and runnig by 

```
docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server
```

## Usage

```bash
$ dotnet run
```

```
http://localhost:5000/
```


### Running migrations 

```
dotnet ef migrations add MigrationName
```

#### Update DataBase 

```
dotnet ef database update
```


## Tests

It's never too early to begin running unit tests. You can learn how to implement tests on [Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test)


## Troubleshooting 


## Git Guideline
Create your branch's and commits using english language and fallowing this guideline.

#### Branches
- Feature:  `feat/branch-name`
- Hotfix: `hotfix/branch-name`
- POC: `poc/branch-name`

#### Commits prefix
- Chore: `chore(context): message`
- Feat: `feat(context): message`
- Fix: `fix(context): message`
- Refactor: `refactor(context): message`
- Tests: `tests(context): message`
- Docs: `docs(context): message`
