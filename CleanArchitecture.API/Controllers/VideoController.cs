using CleanArchitecture.Application.Features.Shared.Queries;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Application.Features.Videos.Queries.PaginationVideos;
using CleanArchitecture.Application.Features.Videos.Queries.Vms;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}", Name = "GetVideo")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(IEnumerable<VideosVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<VideosVm>>> GetVideosByUserName(string username)
        {
            var query = new GetVideosListQuery(username);

            var videos = await _mediator.Send(query);

            return Ok(videos);
        }

        [HttpGet("pagination", Name = "paginationVideo")]
        [Authorize]
        [ProducesResponseType(typeof(PaginationVm<VideosWithIncludesVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<VideosWithIncludesVm>>> GetPaginationVideo([FromQuery] PaginationVideosQuery paginationVideosParams)
        {
            var paginationVideo = await _mediator.Send(paginationVideosParams);

            return Ok(paginationVideo);
        }
    }
}
