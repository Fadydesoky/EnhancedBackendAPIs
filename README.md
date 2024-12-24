Enhanced Backend APIs

This project is a multi-faceted backend solution built using .NET 8.0, offering three different types of APIs: REST, gRPC, and SOAP, alongside a React/Next.js frontend. It is designed for scalability and flexibility, allowing you to handle different types of communication protocols for various client needs.

Key Features:

1- REST API: Provides a traditional RESTful interface for communication. Exposed on port 5147.

2- gRPC API: High-performance and low-latency communication using the gRPC protocol. Exposed on port 5115.

3- SOAP API: A legacy-style API using SOAP protocol for compatibility with older systems. Exposed on port 5269.

4- Frontend (React/Next.js): A modern and responsive user interface built with React and Next.js, running on port 3000.

5- Database: The project uses SQLite as the database solution, providing a lightweight, serverless option. The SQLite database file (shared.db) is shared among all backend services, ensuring data consistency.

Architecture:

Backend APIs: The backend is divided into three services (REST, gRPC, SOAP), each running in separate containers. They all interact with a shared SQLite database (shared.db).

Shared Library: Common code (like AppDbContext and models) is located in a shared folder called SharedLibrary, which is mounted to all backend containers.

Dockerized Environment: The entire application, including the frontend and backend services, is dockerized using Docker Compose for easy setup, management, and scalability.

Technologies Used:

Backend: .NET 8.0 (gRPC, REST, SOAP)

Frontend: React, Next.js

Database: SQLite

Containerization: Docker, Docker Compose

This project is ideal for use cases that require multiple types of API protocols, especially for systems needing high performance (gRPC), compatibility with legacy systems (SOAP), and general API communication (REST). The frontend can easily interact with any of these services, offering flexibility for frontend developers.
