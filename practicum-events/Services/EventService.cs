namespace practicum_events.Services;


using practicum_events.Models;
using practicum_events.DTOs;
using practicum_events.Interfaces;

public class EventService : IEventService
{
    private Dictionary<Guid, Event> _events = new();
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

        //var entity = _events.FirstOrDefault(i => i.Id == id);

        if (_events.TryGetValue(id, out var entity))
        {
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.StartAt = dto.StartAt;
            entity.EndAt = dto.EndAt;

            return CastToDTO(entity);
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
        Guid id = (Guid)(dto.Id == null ? Guid.NewGuid() : dto.Id);
        dto.Id = id;

        return new Event
        {
            Id = id,
            Title = dto.Title,
            StartAt = dto.StartAt,
            EndAt = dto.EndAt,
            Description = dto.Description
        };
    }

    #endregion
}
