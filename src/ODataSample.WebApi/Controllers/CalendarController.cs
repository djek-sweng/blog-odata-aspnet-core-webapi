using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.OData.ModelBuilder;
using ODataSample.Library.Repositories;

namespace ODataSample.WebApi.Controllers;

[Page(MaxTop = 50, PageSize = 10)]
[ApiController]
[Route("calendars")]
public class CalendarController : ODataController
{
    private readonly ICalendarRepository _calendarRepository;

    public CalendarController(ICalendarRepository calendarRepository)
    {
        _calendarRepository = calendarRepository;
    }

    [EnableQuery]
    [HttpGet("query")]
    public IActionResult GetQuery()
    {
        return Ok(_calendarRepository.Query);
    }

    [EnableQuery]
    [HttpGet("list")]
    public IActionResult GetList()
    {
        return Ok(_calendarRepository.List);
    }
}
