using MeetupTime.API.Entities;

namespace MeetupTime.API.Identity;

public interface IJwtProvider
{
    string GenerateJwtToken(User user);
}