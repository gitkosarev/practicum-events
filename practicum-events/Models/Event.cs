namespace practicum_events.Models;

using System.ComponentModel.DataAnnotations;

public class Event
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }

    public string? Description { get; set; }
}
