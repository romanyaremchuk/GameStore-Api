# GameStore API

Minimal **.NET 9** Web API for managing games and genres.  
Stack: **ASP.NET Core**, **EF Core**, **SQLite**.

---

## Run

```bash
dotnet restore
dotnet run
```

API will be available at:

http://localhost:5043

https://localhost:7008

**Endpoints:**
```txt
GET    /games
GET    /games/{id}
POST   /games
PUT    /games/{id}
DELETE /games/{id}
GET    /genres
```
**Config:**
Connection string in appsettings.json:
```json
{
  "ConnectionStrings": {
    "GameStore": "Data Source=GameStore.db"
  }
}
```

**Project Structure:**
```pgsql
/Data        - EF Core context & migrations
/Entities    - Domain models
/Dtos        - API DTOs
/Endpoints   - Minimal API endpoints
/Mapping     - Entity <-> DTO mapping
```
