using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ODataSample.Library.Database;
using ODataSample.Library.Models;

namespace ODataSample.Library.Repositories;

public class CalendarRepository : ICalendarRepository
{
    private readonly DatabaseContext _context;

    public CalendarRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<Calendar> Query => _context.Calendars.AsQueryable();

    public IReadOnlyList<Calendar> List => Query
        .Include(c => c.Meetings)
        .ThenInclude(m => m.Reminders)
        .ToList();
}