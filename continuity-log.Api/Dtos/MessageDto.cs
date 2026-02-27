namespace continuity_log.Api;

//A DTO is a contract betweeen the client and server since it represents
//a shared agreement about how data will be transferred and used.
public record MessageDto(
    int id,
    string message_title,
    string message_content,
    DateOnly posted_date
);
