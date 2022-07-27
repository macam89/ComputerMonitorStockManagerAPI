# ComputerMonitorStockManagerAPI

This project represent simple Web API with MVC through example of computer monitors stock. 
Idea was to create Web API for manage two models - Monitors and Manufacturers.
First step was to create static lists of monitors and manufacturers, and manipulate them 
using controllers HTTP methods (Get, Post, Put, Delete) and Swagger tools. Next step was 
understanding definition of pipeline and middleware; implementing error handler and 
logging with NLog and Basic authorization middleware and set it into pipeline. After this point, 
project is expanded with MS SQL data base, appropriate repositories and interfaces, 
StockContex class using Entity Framework DBContext and Singleton services. 
Project was refactoring with Onion architecture and expand with MVC controllers and views. 
