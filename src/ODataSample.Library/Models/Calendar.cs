using System;
using System.Collections.Generic;

namespace ODataSample.Library.Models;

public class Calendar
{
    public Guid Id { get; set; }
    public string Owner { get; set; } = null!;
    public string Type { get; set; } = null!;
    public bool IsActive { get; set; }

    public ICollection<Meeting> Meetings { get; set; }

    public Calendar()
    {
        Meetings = new HashSet<Meeting>();
    }
}