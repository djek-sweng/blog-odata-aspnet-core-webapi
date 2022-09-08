using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataSample.Library.Repositories;

namespace ODataSample.WebApi.Controllers;

[ApiController]
[Route("meetings")]
public class MeetingController : ODataController
{
    private readonly IMeetingRepository _meetingRepository;

    public MeetingController(IMeetingRepository meetingRepository)
    {
        _meetingRepository = meetingRepository;
    }

    [EnableQuery]
    [HttpGet("query")]
    public IActionResult GetQuery()
    {
        return Ok(_meetingRepository.Query);
    }

    [EnableQuery]
    [HttpGet("list")]
    public IActionResult GetList()
    {
        return Ok(_meetingRepository.List);
    }
}
