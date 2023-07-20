# CSharp Project Template

`Starter template for c# as backend and vue-typescript on frontend projects using a little bit of vertical slice architecture.`

## Table of Contents

- [CSharp Project Template](#csharp-project-template)
  - [Table of Contents](#table-of-contents)
  - [Tech](#tech)
  - [Builtin Packages](#builtin-packages)
    - [Frontend](#frontend)
    - [Backend](#backend)
  - [Requirements](#requirements)
  - [Run using Docker](#run-using-docker)
  - [Development mode](#development-mode)
    - [Helpful commands](#helpful-commands)

## Tech

- [c#](https://docs.microsoft.com/en-us/dotnet/csharp) - is a general-purpose, multi-paradigm programming language.
- [Fast Endpoints](https://fast-endpoints.com) - It nudges you towards the **REPR** Design Pattern (Request-Endpoint-Response) for convenient & maintainable endpoint creation with virtually no boilerplate.
- [Vue](https://vuejs.org) - Front end JavaScript framework for building user interfaces and single-page applications.
- [Vite](https://vitejs.dev/) - Next Generation Frontend Tooling
- [Docker](https://www.docker.com/) - Docker is a set of platform as a service products that use OS-level virtualization to deliver software in packages called containers.
- [SQL Server](https://www.microsoft.com/en-us/sql-server) - SQL Server is a relational database management system developed by Microsoft.
- [Seq](https://datalust.co/seq) - Seq is a powerful log management tool that helps you collect, search, and visualize structured log data from your applications and services.

## Builtin Packages

### Frontend

1. [Vue Router](https://router.vuejs.org) - Vue Router is the official router for Vue.js.
2. [Pinia](https://pinia.esm.dev) - Intuitive, type safe, light and flexible Store for Vue using the composition api with DevTools support.
3. Axios - Promise based HTTP client for the browser and node.js.
4. Auto import - Automatically finds, parses and provides code actions and code completion for all available imports.
5. [Quasar](https://quasar.dev) - Quasar Framework is an MIT-licensed open source project that aims to make building Vue.js apps for all form factors a breeze.
6. [UnoCss](https://unocss.dev) - Uno.css is a utility-first CSS framework for rapid UI development.

### Backend

1. [Fast Endpoints](https://fast-endpoints.com) - It nudges you towards the **REPR** Design Pattern (Request-Endpoint-Response) for convenient & maintainable endpoint creation with virtually no boilerplate.
2. EF Core - Entity Framework (EF) Core is a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology.
3. Mssql - Microsoft SQL Server client for the .NET platform.

## Requirements

1. Dotnet SDK >= 7.0 - <https://dotnet.microsoft.com/download>
2. Node.js = LTS - <https://nodejs.org/en/download>
3. Microsoft SQL Server - <https://www.microsoft.com/en-us/download/details.aspx?id=53344>
4. Docker - <https://www.docker.com>

## Run using Docker

1. Open the terminal and run the following command:

   ```bash
   docker-compose up -d
   ```

2. Open the browser and go to <http://localhost:8000>

## Development mode

1. Open the terminal and run the following command:

   ```bash
   # Run the database
   docker-compose up -d mssql

   # Run the frontend
   pnpm dev

   # Run the backend
   pnpm watch
   ```

2. Open the browser and go to <http://localhost:8000>

### Helpful commands

- Run the application in development mode
- `pnpm dev` - Run the frontend in development mode
- `pnpm watch` - Run the backend in development mode

- Database
- `pnpm db:update` - Update the database (optional parameter: MIGRATION_NAME)
- `pnpm db:drop` - Drop the database (WARNING: This will delete all data)

- Migrations
- `pnpm migrations:add MIGRATION_NAME` - Create a new migration
- `pnpm migrations:remove` - Remove the last migration

- Seeders
- `pnpm seed` - Migrate and seed the database

[⬆ Back to Top](#table-of-contents)
