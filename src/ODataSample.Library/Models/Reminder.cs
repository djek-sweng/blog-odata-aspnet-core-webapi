using System;

namespace ODataSample.Library.Models;

public class Reminder
{
    public Guid Id { get; set; }
    public uint RemindBefore { get; set; }
    public Guid MeetingId { get; set; }

    public Meeting Meeting { get; set; } = null!;

    public Reminder()
    {
    }
}