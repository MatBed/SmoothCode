using HR.LeaveManagement.Core;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.IntegrationTests;

public class HrDatabaseContextTests
{
    private HrDatabaseContext _hrDatabaseContext;

    public HrDatabaseContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _hrDatabaseContext = new HrDatabaseContext(dbOptions);
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
