using AutoMapper;
using MeetupTime.API.Authorization;
using MeetupTime.API.Entities;
using MeetupTime.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MeetupTime.API.Controllers;

[Route("api/meetup")]
[Authorize]
public class MeetupController : ControllerBase
{
    private readonly Context _context;
    private readonly IMapper _mappper;
    private readonly IAuthorizationService _authorizationService;

    public MeetupController(Context context, IMapper mappper, IAuthorizationService authorizationService)
    {
        _context = context;
        _mappper = mappper;
        _authorizationService = authorizationService;
    }

    [HttpGet]
    public ActionResult<List<MeetupDetailsDto>> Get()
    {
        var meetups = _context.Meetups.ToList();
        var meetupsDto = _mappper.Map<List<MeetupDetailsDto>>(meetups);

        return Ok(meetupsDto);
    }

    [HttpGet("{name}")]
    [Authorize(Policy = "AtLeast18")]
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
    [Authorize(Roles = "Admin,Moderator")]
    public ActionResult Post([FromBody]MeetupDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var meetup = _mappper.Map<Meetup>(model);

        var userId = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

        meetup.CreatedById = int.Parse(userId);

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

        var authorizationResult = _authorizationService.AuthorizeAsync(User, meetup, new ResourceOperationRequirement(OperationType.Update)).Result;

        if (!authorizationResult.Succeeded)
        {
            return Forbid();
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

        var authorizationResult = _authorizationService.AuthorizeAsync(User, meetup, new ResourceOperationRequirement(OperationType.Update)).Result;

        if (!authorizationResult.Succeeded)
        {
            return Forbid();
        }

        _context.Remove(meetup);
        _context.SaveChanges();

        return NoContent();
    }
}
