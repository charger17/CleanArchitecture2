﻿using CleanArchitecture.Application.Features.Shared.Queries;
using CleanArchitecture.Application.Features.Videos.Queries.Vms;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.PaginationVideos
{
    public class PaginationVideosQuery : PaginationBaseQuery, IRequest<PaginationVm<VideosWithIncludesVm>>
    {
        public int? StreamerId { get; set; }

        public int? DirectorId { get; set; }
    }
}
