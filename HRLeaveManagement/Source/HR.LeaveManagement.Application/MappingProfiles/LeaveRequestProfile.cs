using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using HR.LeaveManagement.Core;

namespace HR.LeaveManagement.Application.MappingProfiles;
internal class LeaveRequestProfile : Profile
{
    public LeaveRequestProfile()
    {
        CreateMap<LeaveRequestListDto, LeaveRequest>().ReverseMap();
        CreateMap<LeaveRequestDetailsDto, LeaveRequest>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
        CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
        CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
    }
}