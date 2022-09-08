using System;
using System.Collections.Generic;

namespace ODataSample.Library.Models;

public class Meeting
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartAt { get; set; }
    public uint Duration { get; set; }
    public Guid CalendarId { get; set; }

    public Calendar Calendar { get; set; } = null!;
    public ICollection<Reminder> Reminders { get; set; }

    public Meeting()
    {
        Reminders = new HashSet<Reminder>();
    }
}