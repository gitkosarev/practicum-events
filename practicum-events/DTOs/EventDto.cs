namespace practicum_events.DTOs;

using System.ComponentModel.DataAnnotations;


public class EventDto : IValidatableObject
{
    public Guid Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Название обязательно для заполнения")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Дата начала обязательна для заполнения")]
    public DateTime? StartAt { get; set; }

    [Required(ErrorMessage = "Дата завершения обязательна для заполнения")]
    public DateTime? EndAt { get; set; }

    public string? Description { get; set; }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndAt <= StartAt)
        {
            yield return new ValidationResult(
                "Дата завершения должна быть больше даты начала",
                new[] { nameof(EndAt) }
            );
        }
    }
}

