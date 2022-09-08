using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ODataSample.Library.Database;
using ODataSample.Library.Models;

namespace ODataSample.Library.Repositories;

public class MeetingRepository : IMeetingRepository
{
    private readonly DatabaseContext _context;

    public MeetingRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<Meeting> Query => _context.Meetings.AsQueryable();

    public IReadOnlyList<Meeting> List => Query
        .Include(m => m.Calendar)
        .Include(m => m.Reminders)
        .ToList();
}