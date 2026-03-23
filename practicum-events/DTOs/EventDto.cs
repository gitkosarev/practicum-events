namespace practicum_events.DTOs;

using System.ComponentModel.DataAnnotations;


public class EventDto
{
    public Guid? Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public DateTime StartAt { get; set; }

    [Required]
    public DateTime EndAt { get; set; }

    public string? Description { get; set; }
}

