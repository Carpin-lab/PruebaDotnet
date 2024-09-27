# PruebaDotNet_React

This is a simple project on .NET.
To demonstrate what I have learned about .net

### Keep in mind:

If your using VCode you have to install some extensions:

    - .NET Install tool
    - C# Dev Kit
    - NutGet Gallery

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/Carpin-lab/PruebaDotnet.git
   ```
2. Navigate to the project directory:
   ```sh
   cd PruebaDotnet
   ```
3. Install .NET dependencies:
   ```sh
   dotnet restore
   ```

### Running the Application

1. Start the .NET backend:
   ```sh
   dotnet run
   ```

### Database

Using a SqlServer database, the name should be `BdPrueba`.
To configure it go to `appsettings` and change the connection string

#### Migrations

To do a migrations use this command:
`dotnet-ef migrations add "text"`

To save this migration in the database use:
`dotnet-ef update database`

## License

This project is licensed under the PP license by the company Perry el Platitorrinco S.A
