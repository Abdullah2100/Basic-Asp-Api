## Fake API

This project is a dummy API that manages data for a table called 'Fack.' It is primarily for learning purposes. It is just a learning process.

### Technologies Used

- ASP.NET (3-tier architecture)
- Microsoft.Data.SqlClient
- Microsoft.Extensions.Configuration

### Prerequisites

To run this project, you need:

- SQL Server installed with any version.
- Update the connection string in the `appSettings.json` file in the ASP.NET project.

### Installation

1. Clone the repository:

   ```shell
   git clone https://github.com/Abdullah2100/Basic-Asp-Api.git
   ```

2. Open the solution in Visual Studio.

3. Update the connection string in the `appSettings.json` file located in the ASP.NET project. Replace `<connection-string>` with your actual connection string.

   ```json
   {
     "Configurations": {
       "DefaultConnection": "<connection-string>"
     }
   }
   ```

4. Build and run the solution in Visual Studio.

### API Endpoints

The following API endpoints are available:

- **GET /api/Fack** - Get all Facks.

- **GET /api/Fack/{id}** - Get a fack by ID.

- **POST /api/Fack** -According to what you send (if id is found it will update or it will add) it will add or update fack 
- **DELETE /api/Fack/{id}** - Delete a fack by ID.

### Swagger Documentation

You can access the Swagger documentation for this API by running the project and navigating to the following URL: `http://localhost:<port>/swagger/index.html`. This will provide detailed information about the API endpoints, request/response examples, and allow you to interact with the API directly from the Swagger UI.

### Examples

#### Get all Fack

**Request:**

```
GET /api/Fack
```

**Response:**

```json
[
  {
    "fackID": 1,
    "name": "John Doe",
    "job": "Engineer",
    "isDeleted": false
  },
  {
    "fackID": 2,
    "name": "Jane Smith",
    "job": "Designer",
    "isDeleted": false
  }
]
```

#### Get a fack by ID

**Request:**

```
GET /api/Fack/1
```

**Response:**

```json
{
  "fackID": 1,
  "name": "John Doe",
  "job": "Engineer",
  "isDeleted": false
}
```

#### Add a new fack

**Request:**

```
POST /api/Fack
Content-Type: application/json

{
  "name": "Alice Johnson",
  "job": "Manager"
}
```

**Response:**

```json
{
  "fackID": 3,
  "name": "Alice Johnson",
  "job": "Manager",
  "isDeleted": false
}
```

#### Update an existing fack

**Request:**

```
POST /api/Fack
Content-Type: application/json

{
  "fackID": 1,
  "name": "John Doe",
  "job": "Senior Engineer"
}
```

**Response:**

```json
{
  "fackID": 1,
  "name": "John Doe",
  "job": "Senior Engineer",
  "isDeleted": false
}
```

#### Delete a fack by ID

**Request:**

```
DELETE /api/Fack/1
```

**Response:**

```
No content
```

Certainly! Here's the updated template with the requested change:

## Fake API

This project is a dummy API that manages data for a table called "Facks".

### Technologies Used

- ASP.NET (3-tier architecture)
- Microsoft.Data.SqlClient
- Microsoft.Extensions.Configuration

### Prerequisites

To run this project, you need:

- SQL Server installed with any version.
- Update the connection string in the `appSettings.json` file in the ASP.NET project.

### Installation

1. Clone the repository:

   ```shell
   git clone https://github.com/your-username/fake-api.git
   ```

2. Open the solution in Visual Studio.

3. Update the connection string in the `appSettings.json` file located in the ASP.NET project. Replace `<connection-string>` with your actual connection string.

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "<connection-string>"
     }
   }
   ```

4. Build and run the solution in Visual Studio.

### API Endpoints

The following API endpoints are available:

- **GET /api/facks** - Get all facks.

- **GET /api/facks/{id}** - Get a fack by ID.

- **POST /api/facks** - Add a new fack. Include the fack details in the request body.

- **PUT /api/facks/{id}** - Update an existing fack. Include the fack details in the request body.

- **DELETE /api/facks/{id}** - Delete a fack by ID.

### Swagger Documentation

You can access the Swagger documentation for this API by running the project and navigating to the following URL: `http://localhost:<port>/swagger/index.html`. This will provide detailed information about the API endpoints, request/response examples, and allow you to interact with the API directly from the Swagger UI.

### Examples

#### Get all facks

**Request:**

```
GET /api/facks
```

**Response:**

```json
[
  {
    "fackId": 1,
    "name": "John Doe",
    "job": "Engineer",
    "isDeleted": false
  },
  {
    "fackId": 2,
    "name": "Jane Smith",
    "job": "Designer",
    "isDeleted": false
  }
]
```

#### Get a fack by ID

**Request:**

```
GET /api/facks/1
```

**Response:**

```json
{
  "fackId": 1,
  "name": "John Doe",
  "job": "Engineer",
  "isDeleted": false
}
```

#### Add a new fack

**Request:**

```
POST /api/facks
Content-Type: application/json

{
  "name": "Alice Johnson",
  "job": "Manager"
}
```

**Response:**

```json
{
  "fackId": 3,
  "name": "Alice Johnson",
  "job": "Manager",
  "isDeleted": false
}
```

#### Update an existing fack

**Request:**

```
PUT /api/facks/1
Content-Type: application/json

{
  "name": "John Doe",
  "job": "Senior Engineer"
}
```

**Response:**

```json
{
  "fackId": 1,
  "name": "John Doe",
  "job": "Senior Engineer",
  "isDeleted": false
}
```

#### Delete a fack by ID

**Request:**

```
DELETE /api/facks/1
```

**Response:**

```
No content
```

Feel free to open an issue if you encounter any errors or have any questions regarding the code. We'll be happy to fix error 
