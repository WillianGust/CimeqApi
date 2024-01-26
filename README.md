
**Cimeq API - Client and Order CRUD Operations**
* Overview
* This project demonstrates the implementation of a client-server application using Visual Studio 2022, Blazor, C# with .NET 6.0, and the Cimeq API. The application focuses on providing CRUD (Create, Read, Update, Delete) functionality for clients and orders.

**Prerequisites**
Make sure you have the following software installed on your machine:

Visual Studio 2022
.NET 6.0 SDK
Cimeq API
Getting Started
Clone the Repository:

**bash**

* git clone https://github.com/your-username/your-repo.git
* cd your-repo
* Open Solution in Visual Studio:
* Open the solution file (YourSolution.sln) in Visual Studio 2022.

**Configure Cimeq API:**
* Ensure that the Cimeq API is set up and running. Update the API endpoint and any required authentication details in the appsettings.json file.

**Build and Run:**
* Build and run the solution in Visual Studio.

**Explore the Application:**
* Open your web browser and navigate to the application. You should be able to perform CRUD operations for clients and orders.

**API Endpoints**
**Clients**
* GET /api/clients

**Retrieve a list of all clients.**
* GET /api/clients/{id}

**Retrieve details of a specific client by ID**.
* POST /api/clients

**Create a new client.**
* Request Body:

{
  "name": "Client Name",
  "email": "client@example.com",
  "phone": "123-456-7890"
}

**PUT /api/clients/{id}**

* Update an existing client by ID.
* Request Body:
  
{
  "name": "Updated Client Name",
  "email": "updated-client@example.com",
  "phone": "987-654-3210"
}
**DELETE /api/clients/{id}**

* Delete a client by ID.
* Orders
  
**GET /api/orders**

* Retrieve a list of all orders.

**GET /api/orders/{id}**

**Retrieve details of a specific order by ID.**
POST /api/orders

**Create a new order.**
Request Body:
{
  "clientId": 1,
  "product": "Product Name",
  "quantity": 5,
  "totalAmount": 100.00
}
PUT /api/orders/{id}

**Update an existing order by ID.**
* Request Body:

{
  "clientId": 1,
  "product": "Updated Product Name",
  "quantity": 10,
  "totalAmount": 200.00
}
**DELETE /api/orders/{id}**

* Delete an order by ID.
