﻿using AutoMapper;
using CleanArchitecture.Application.Features.Directors.Commands.CreateDirector;
using CleanArchitecture.Application.Features.Directors.Queries.Vms;
using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Features.Streamers.Queries.Vms;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>().ReverseMap();
            CreateMap<CreateStreamerCommand, Streamer>().ReverseMap();
            CreateMap<UpdateStreamerCommand, Streamer>().ReverseMap();
            CreateMap<CreateDirectorCommand, Director>().ReverseMap();
            CreateMap<Streamer, StreamersVm>().ReverseMap();
            CreateMap<Director, DirectorVm>().ReverseMap();
        }
    }
}
