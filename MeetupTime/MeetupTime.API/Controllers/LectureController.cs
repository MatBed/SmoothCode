using AutoMapper;
using MeetupTime.API.Entities;
using MeetupTime.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetupTime.API.Controllers;

[Route("api/meetup/{meetupName}/lecture")]
public class LectureController : ControllerBase
{
    private readonly Context _context;
    private readonly IMapper _mapper;

    public LectureController(Context context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult Post(string meetupName, [FromBody] LectureDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var meetup = _context.Meetups
            .Include(m => m.Lectures)
            .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == meetupName.ToLower());

        if (meetup == null)
        {
            return NotFound();
        }

        var lecture = _mapper.Map<Lecture>(model);
        meetup.Lectures.Add(lecture);
        _context.SaveChanges();

        return Created($"api/meetup/{meetupName}", null);
    }

    [HttpGet]
    public ActionResult Get(string meetupName)
    {
        var meetup = _context.Meetups
            .Include(m => m.Lectures)
            .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == meetupName.ToLower());

        if (meetup == null)
        {
            return NotFound();
        }

        var lectures = _mapper.Map<List<LectureDto>>(meetup.Lectures);

        return Ok(lectures);
    }

    [HttpDelete]
    public ActionResult Delete(string meetupName)
    {
        var meetup = _context.Meetups
            .Include(m => m.Lectures)
            .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == meetupName.ToLower());

        if (meetup == null)
        {
            return NotFound();
        }

        _context.Lectures.RemoveRange(meetup.Lectures);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string meetupName, int id)
    {
        var meetup = _context.Meetups
            .Include(m => m.Lectures)
            .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == meetupName.ToLower());

        if (meetup == null)
        {
            return NotFound();
        }

        var lecture = meetup.Lectures.FirstOrDefault(x => x.Id == id);

        if (lecture == null)
        {
            return NotFound();
        }

        _context.Lectures.Remove(lecture);
        _context.SaveChanges();

        return NoContent();
    }
}
