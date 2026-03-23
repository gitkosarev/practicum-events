using practicum_events.DTOs;
using practicum_events.Models;

namespace practicum_events.Interfaces;

public interface IEventService
{
    List<EventDto> GetAll();
    EventDto? GetById(Guid id);
    EventDto? Create(EventDto entity);
    EventDto? Update(Guid id, EventDto entity);
    bool Delete(Guid id);
}

