//creates the builder object
var builder = WebApplication.CreateBuilder(args);

//configure the application through the builder object


//calls .Build from the builder object
var app = builder.Build();

//defining that when the root is called through HTTP it will return hello world
app.MapGet("/", () => "Hello World!");

//runs the application
app.Run();
