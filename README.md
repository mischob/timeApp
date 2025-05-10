# TimeTracker Application

A time tracking application built with ASP.NET Core 9 and Blazor WebAssembly.

## Project Structure

- **TimeTracker.Api**: Backend API project
- **TimeTracker.Client**: Blazor WebAssembly client project
- **TimeTracker.Shared**: Shared library for models and constants

## Prerequisites

- .NET 9 SDK
- Visual Studio 2022 or later (recommended)
- Docker (optional, for containerization)

## Getting Started

### Clone the Repository

```bash
git clone <repository-url>
cd timeApp
```

### Build the Solution

```bash
dotnet build
```

### Run the API

```bash
cd src/TimeTracker.Api
dotnet run
```

### Run the Client

```bash
cd src/TimeTracker.Client
dotnet run
```

## Docker Support

Docker support will be added in future updates.

## Authentication

This application uses Azure AD B2C for authentication. Configuration will be added in a future update.

## License

[MIT](LICENSE) 