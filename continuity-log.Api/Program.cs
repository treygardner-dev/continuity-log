//creates the builder object
using System.ComponentModel.DataAnnotations;
using continuity_log.Api;
using continuity_log.Api.Dtos;

const string GetMessageEndPoint = "GetMessage";

var builder = WebApplication.CreateBuilder(args);

//configure the application through the builder object


//calls .Build from the builder object
var app = builder.Build();

//temporary list of messages to handle
List<MessageDto> messages = [
    new (1, "Test message!", "This message has important information in it that needs to be read", new DateOnly(2026, 1, 25)),
    new (2, "Response message?", "This message has important information in it that needs to be read", new DateOnly(2026, 1, 25)),
    new (3, "Ending message.", "This message has important information in it that needs to be read", new DateOnly(2026, 1, 25))
];

//GET : /messages
app.MapGet("/messages", () => messages);


// GET /games/1
app.MapGet("/messages/{id}", (int id) => messages.Find(e => e.id == id))
    .WithName(GetMessageEndPoint);

// POST /messages
app.MapPost("/messages", (CreateMessageDto new_message) =>
{
    MessageDto message = new(
        messages.Count + 1,
        new_message.message_title,
        new_message.message_content,
        new_message.posted_date
    );

    messages.Add(message);

    return Results.CreatedAtRoute(GetMessageEndPoint, new {id = message.id}, message);
});


//defining that when the root is called through HTTP it will return hello world
app.MapGet("/", () => "Hello World!");

//runs the application
app.Run();
