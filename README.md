# TaskManager

TaskManager is a web app for managing tasks and projects in a Kanban style, built with Blazor Server, Entity Framework Core, and PostgreSQL.

## Features

- **Board Management**: Create, edit, and delete project boards.
- **Task Lists**: Add custom columns (lists) to each board.
- **Tasks**: Add, edit, delete, and move tasks between lists using drag & drop.
- **Priorities**: Assign priorities to tasks and manage their order.
- **Authentication**: Login/logout with Auth0.
- **Responsive UI**: Modern interface using Bootstrap 5 and Radzen.

## Demo

![Demo App](docs/demo.gif)

## Project Structure

- `Components/`  
  Blazor components for boards, lists, tasks, dialogs, layout, etc.
- `Models/`  
  Data models for Board, TaskList, Task, TaskPriority.
- `Services/`  
  Services for data access and application state.
- `wwwroot/`  
  Static files, CSS, JS, images.

## Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/)
- An [Auth0](https://auth0.com/) account for authentication

## Setup

1. **Clone the repository**
   ```bash
   git clone <repo-url>
   cd TaskManager
   ```

2. **Configure the database**
   - Set your PostgreSQL connection string in `appsettings.json` or via the `DefaultConnection` environment variable.

3. **Configure Auth0**
   - Add your `Auth0:Domain` and `Auth0:ClientId` keys in `appsettings.json` or as environment variables.

4. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the app**
   ```bash
   dotnet run --launch-profile https
   ```
   The app will be available at [http://localhost:7243](http://localhost:7243).

## Drag & Drop Between Lists

To move a task between lists on the same board:
- Drag the desired task and drop it onto the target list.
- The backend will update the task's associated list.

## Main Dependencies

- [Blazor Server](https://learn.microsoft.com/aspnet/core/blazor/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [Npgsql](https://www.npgsql.org/)
- [Radzen.Blazor](https://blazor.radzen.com/)
- [Bootstrap 5](https://getbootstrap.com/)

**Author:** Mattia Toscanelli