using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practicum_events.DTOs;
using practicum_events.Interfaces;

namespace practicum_events.Controllers;



[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _eventService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        EventDto? result = _eventService.GetById(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create([FromBody] EventDto dto)
    {
        EventDto? result = _eventService.Create(dto);
        if (result == null)
            return Conflict();

        return Created(string.Empty, result);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] EventDto dto)
    {
        EventDto? result = _eventService.Update(id, dto);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        bool result = _eventService.Delete(id);
        return result? NoContent() : NotFound();
    }
}
