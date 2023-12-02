using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Core;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Persistence.IntegrationTests;

public class HrDatabaseContextTests
{
    private HrDatabaseContext _hrDatabaseContext;
    private readonly string _userId;
    private readonly Mock<IUserService> _userServiceMock;
    public HrDatabaseContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        _userId = "00000000-0000-0000-0000-000000000000";
        _userServiceMock = new Mock<IUserService>();
        _userServiceMock.Setup(m => m.UserId).Returns(_userId);

        _hrDatabaseContext = new HrDatabaseContext(dbOptions, _userServiceMock.Object);
    }

    [Fact]
    public async Task Save_SetDateCreatedValue()
    {
        var leaveType = new LeaveType
        {
            Id = 1,
            DefaultDays = 10,
            Name = "Test Vacation"
        };

        _hrDatabaseContext.LeaveTypes.Add(leaveType); 
        await _hrDatabaseContext.SaveChangesAsync();

        leaveType.DateCreated.ShouldNotBeNull();
    }

    [Fact]
    public async Task Save_SetDateModifiedValue()
    {
        var leaveType = new LeaveType
        {
            Id = 1,
            DefaultDays = 10,
            Name = "Test Vacation"
        };

        _hrDatabaseContext.LeaveTypes.Add(leaveType);
        await _hrDatabaseContext.SaveChangesAsync();

        leaveType.DateModified.ShouldNotBeNull();
    }
}
