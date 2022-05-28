using AutoMapper;
using MeetupTime.API.Entities;
using MeetupTime.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetupTime.API.Controllers;

[Route("api/meetup")]
public class MeetupController : ControllerBase
{
    private readonly Context _context;
    private readonly IMapper _mappper;

    public MeetupController(Context context, IMapper mappper)
    {
        _context = context;
        _mappper = mappper;
    }

    [HttpGet]
    public ActionResult<List<MeetupDetailsDto>> Get()
    {
        var meetups = _context.Meetups.ToList();
        var meetupsDto = _mappper.Map<List<MeetupDetailsDto>>(meetups);

        return Ok(meetupsDto);
    }

    [HttpGet("{name}")]
    public ActionResult<MeetupDetailsDto> Get(string name)
    {
        var meetup = _context.Meetups
            .Include(m => m.Location)
            .Include(m => m.Lectures)
            .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.ToLower());

        if (meetup == null)
        {
            return NotFound();
        }

        var meetupDto = _mappper.Map<MeetupDetailsDto>(meetup);

        return Ok(meetupDto);
    }

    [HttpPost]
    public ActionResult Post([FromBody]MeetupDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var meetup = _mappper.Map<Meetup>(model);
        _context.Meetups.Add(meetup);
        _context.SaveChanges();

        var key = meetup.Name.Replace(" ", "-").ToLower();

        return Created($"api/meetup/{key}", null);
    }

    [HttpPut("{name}")]
    public ActionResult Put(string name, [FromBody] MeetupDto model)
    {
        var meetup = _context.Meetups
            .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.ToLower());

        if (meetup == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        meetup.Name = model.Name;
        meetup.Organizer = model.Organizer;
        meetup.Date = model.Date;
        meetup.IsPrivate = model.IsPrivate;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{name}")]
    public ActionResult Delete(string name)
    {
        var meetup = _context.Meetups
            .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.ToLower());

        if (meetup == null)
        {
            return NotFound();
        }

        _context.Remove(meetup);
        _context.SaveChanges();

        return NoContent();
    }
}
