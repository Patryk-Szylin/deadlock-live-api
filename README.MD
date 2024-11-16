
# Live Match Tracker - Setup Guide

## Prerequisites

1. **.NET Core SDK**: Ensure the latest .NET Core SDK is installed.
2. **Docker**: Ensure Docker is installed and running on your machine.

---

## Steps to Run the Project

### 1. Clone the Repository

Clone the project repository to your local machine:
```bash
git clone <repository_url>
cd <repository_folder>
```

### 2. Start Required Services

Use the provided `docker-compose.yml` file to start Kafka, Zookeeper, and Redis:
```bash
docker-compose up -d
```

This will spin up the following services:
- **Redis** (Port: `6379`)
- **Kafka** (Port: `9092`)
- **Zookeeper** (Port: `2181`)

---

### 3. Configure the Application

Ensure the following settings are in your `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Redis": "localhost:6379"
  },
  "Kafka": {
    "BootstrapServers": "localhost:9092"
  }
}
```

---

### 4. Build and Run the Project

Restore dependencies, build, and run the application:

```bash
dotnet build
dotnet run
```

---

### 5. Access the API

Once the project is running, you can access the API and Swagger documentation:

- **API Base URL**: `https://localhost:5001/api/matches/`
- **Swagger Documentation**: `https://localhost:5001/swagger`

---

## API Endpoints

### 1. Start a Match Stream
- **Endpoint**: `POST /{matchId}/start-stream`
- **Description**: Starts watching a live match stream for the provided `matchId`.
- **Response**: Returns a success message or conflict if already started.

---

### 2. Stop a Match Stream
- **Endpoint**: `POST /{matchId}/stop-stream`
- **Description**: Stops watching a live match stream for the provided `matchId`.
- **Response**: Returns a success message or `404` if not active.

---

### 3. Get Live Matches
- **Endpoint**: `GET /`
- **Description**: Lists all currently active live match streams.
- **Response**: Returns a list of active match streams.

---

## Running Notes

- Ensure Docker services are running before launching the app.
- Use the Swagger interface to interact with the API and test endpoints.

---
