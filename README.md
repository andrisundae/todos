1. Create Domain and Models
2. Create controller
3. Create interface
To define an expected behavior for something in C# (and in other object-oriented languages, such as Java, for example), we define an interface. An interface tells how something should work, but does not implement the real logic for the behavior. The logic is implemented in classes that implement the interface
4. Repository Pattern
When using the Repository Pattern, we define repository classes, that basically encapsulate all logic to handle data access. These repositories expose methods to list, create, edit and delete objects of a given model, the same way you can manipulate collections. Internally, these methods talk to the database to perform CRUD operations, isolating the database access from the rest of the application.
5. Persistence
This directory is going to have everything we need to access the database, such as repositories implementations.
6. BaseRepository
This class is just an abstract class that all our repositories will inherit. An abstract class is a class that don’t have direct instances. You have to create direct classes to create the instances.
The BaseRepository receives an instance of our AppDbContext through dependency injection and exposes a protected property (a property that can only be accessible by the children classes) called _context, that gives access to all methods we need to handle database operations.


IAM SORRY...CANNOT COMPLETE THE TASK

I Use seeder

Just :
POST /api/todos
PUT /api/todos
DELETE /api/todos/100
GET /api/todos
GET /api/todos/100