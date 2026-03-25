namespace practicum_events.Services;


using practicum_events.Models;
using practicum_events.DTOs;
using practicum_events.Interfaces;

public class EventService : IEventService
{
    private static Dictionary<Guid, Event> _events = new();
    public IReadOnlyCollection<Event> Events => _events.Values.ToList().AsReadOnly();

    public List<EventDto> GetAll()
    {
        return _events.Values.ToList().Select(i => CastToDTO(i)).ToList();
    }

    public EventDto? GetById(Guid id)
    {
        if (_events.TryGetValue(id, out var entity))
            return CastToDTO(entity);

        return null;
    }

    public EventDto? Create(EventDto dto)
    {
        if (dto.Id == default)
            dto.Id = Guid.NewGuid();

        var entity = CastToEntity(dto);
        if (_events.ContainsKey(entity.Id))
            return null;

        _events[entity.Id] = entity;
        return dto;
    }

    public EventDto? Update(Guid id, EventDto dto)
    {
        if (id == default)
            return null;

        var entity = CastToEntity(dto);

        if (_events.TryGetValue(id, out var value))
        {
            value.Title = entity.Title;
            value.Description = entity.Description;
            value.StartAt = entity.StartAt;
            value.EndAt = entity.EndAt;

            return CastToDTO(value);
        }
        else
        {
            return null;
        }
    }

    public bool Delete(Guid id)
    {
        if (_events.Remove(id))
            return true;

        return false;
    }



    #region Methods: Private

    private EventDto CastToDTO(Event entity)
    {
        return new EventDto
        {
            Id = entity.Id,
            Title = entity.Title,
            StartAt = entity.StartAt,
            EndAt = entity.EndAt,
            Description = entity.Description
        };
    }

    private Event CastToEntity(EventDto dto)
    {
        return new Event
        {
            Id = dto.Id,
            Title = dto.Title,
            StartAt = dto.StartAt ?? DateTime.MinValue,
            EndAt = dto.EndAt ?? DateTime.MinValue,
            Description = dto.Description
        };
    }

    #endregion
}
