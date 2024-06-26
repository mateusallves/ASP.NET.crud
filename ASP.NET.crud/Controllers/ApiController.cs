﻿
using ASP.NET.crud.Entities;
using ASP.NET.crud.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.crud.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDb _context;

        public DevEventsController(DevEventsDb context)
        {
            _context = context;
        }

        // api/dev-events GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _context.DevEvents.Where(d => !d.isDeleted).ToList();

            return Ok(devEvents);
        }

        // api/dev-events/2722b2a6-27d7-43c9-8ecc-3d9509e4656e GET
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _context.DevEvents
                .Include(e=> e.Speaker)
                .SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            return Ok(devEvent);
        }

        // api/dev-events/ POST
        [HttpPost]
        public IActionResult Post(DevEvents devEvent)
        {
            _context.DevEvents.Add(devEvent);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }

        // api/dev-events/2722b2a6-27d7-43c9-8ecc-3d9509e4656e PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvents input)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Update(input.Title, input.Description, input.StartDate, input.EndDate);
            _context.DevEvents.Update(devEvent);
            _context.SaveChanges();

            return NoContent();
        }

        // api/dev-events/2722b2a6-27d7-43c9-8ecc-3d9509e4656e DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Delete();
            _context.SaveChanges();

            return NoContent();
        }

        // api/dev-events/2722b2a6-27d7-43c9-8ecc-3d9509e4656e/speakers
        [HttpPost("{id}/speakers")]
        public IActionResult PostSpeaker(Guid id, DevEventSpeaker speaker)
        {
            speaker.DevEventId = id;
            var devEvent = _context.DevEvents.Any(d => d.Id == id);

            if (!devEvent)
            {
                return NotFound();
            }

            _context.DevEventSpeaker.Add(speaker);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
