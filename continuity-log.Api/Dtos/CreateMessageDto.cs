namespace continuity_log.Api.Dtos;

public record CreateMessageDto(
    string message_title,
    string message_content,
    DateOnly posted_date
);

