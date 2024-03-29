﻿using AutoMapper;
using MeetupTime.API.Entities;
using MeetupTime.API.Models;

namespace MeetupTime.API;

public class MeetupProfile : Profile
{
    public MeetupProfile()
    {
        CreateMap<Meetup, MeetupDetailsDto>()
            .ForMember(m => m.City, map => map.MapFrom(meetup => meetup.Location.City))
            .ForMember(m => m.PostCode, map => map.MapFrom(meetup => meetup.Location.PostCode))
            .ForMember(m => m.Street, map => map.MapFrom(meetup => meetup.Location.Street));

        CreateMap<MeetupDto, Meetup>();

        CreateMap<LectureDto, Lecture>()
            .ReverseMap();
    }
}
