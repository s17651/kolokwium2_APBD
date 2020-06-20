using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolpkwium2_APBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kolpkwium2_APBD.Controllers
{
    [Route("api/artist")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ClientDbContext _context;

        public ArtistController(ClientDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetArtist(int id)
        {
            if (id < 1)
                return BadRequest("ID must be positive number");

            var artist = _context.Artist
                            .Where(a => a.IdArtist == id)
                            .FirstOrDefault();
            
            if (artist == null)
                return BadRequest("There's no Artist with such a ID");

            var artistEvents = _context.ArtistEvent
                                .Where(ae => ae.IdArtist == id).ToList();

            var events = _context.Event
                            .Where(e => artistEvents.Any(ae => ae.IdEvent == e.IdEvent))
                            .OrderByDescending(e => e.StartDate).ToList();

            ArtistEventResponse response = new ArtistEventResponse
            {
                Artist = artist,
                Events = events
            };
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateArtistEvent(ArtistEventRequest request)
        {
            var artistEvent = _context.ArtistEvent
                                .Where(ae => ae.IdArtist == request.IdEvent && ae.IdEvent == request.IdEvent)
                                .FirstOrDefault();
            if (artistEvent == null)
            {
                return BadRequest("There's no such Event");
            }

            var foundEvent = _context.Event
                        .Where(e => e.IdEvent == artistEvent.IdEvent).FirstOrDefault();
            
            if (!(request.PerformanceDate > foundEvent.StartDate && request.PerformanceDate < foundEvent.EndDate))
                return BadRequest("This Event has already started");

            var newArtistEvent = new ArtistEvent
            {
                IdArtist = artistEvent.IdArtist,
                IdEvent = artistEvent.IdEvent,
                PerformanceDate = request.PerformanceDate
            };

            _context.Attach(newArtistEvent);
            _context.Entry(newArtistEvent).State = EntityState.Modified;
            
            return Ok(201);
        }

}