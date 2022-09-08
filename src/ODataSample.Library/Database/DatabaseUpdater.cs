using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ODataSample.Library.Models;

namespace ODataSample.Library.Database;

public class DatabaseUpdater
{
    private readonly IApplicationBuilder _applicationBuilder;

    private DatabaseUpdater(IApplicationBuilder applicationBuilder)
    {
        _applicationBuilder = applicationBuilder;
    }

    public static DatabaseUpdater Create(IApplicationBuilder applicationBuilder)
    {
        return new DatabaseUpdater(applicationBuilder);
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        using var scope = _applicationBuilder.ApplicationServices.CreateScope();

        var context = scope.ServiceProvider.GetService<DatabaseContext>()
                      ?? throw new Exception("Could not get database context.");

        await MigrateDatabaseAsync(context, cancellationToken);
        await InsertSampleDataAsync(context, cancellationToken);
    }

    private static async Task MigrateDatabaseAsync(DbContext context, CancellationToken cancellationToken)
    {
        await context.Database.MigrateAsync(cancellationToken);

        Console.WriteLine("Migrating database ... done!");
    }

    private static async Task InsertSampleDataAsync(DatabaseContext context, CancellationToken cancellationToken)
    {
        if (context.Calendars.Any())
        {
            return;
        }

        /*
         * Add Arthur's calendar.
         */
        var calendar = new Calendar
        {
            Id = Guid.NewGuid(),
            Owner = "Arthur Dent",
            Type = "personal",
            IsActive = true
        };

        var meeting = new Meeting
        {
            Id = Guid.NewGuid(),
            Title = "Have lunch with Zaphod Beeblebrox",
            Description = "Ford's semi-half-cousin likes tea",
            Duration = 42,
            StartAt = DateTime.UtcNow.AddDays(4),
            CalendarId = calendar.Id
        };
        meeting.Reminders.Add(new Reminder
        {
            Id = Guid.NewGuid(),
            RemindBefore = 120,
            MeetingId = meeting.Id
        });
        meeting.Reminders.Add(new Reminder
        {
            Id = Guid.NewGuid(),
            RemindBefore = 60,
            MeetingId = meeting.Id
        });
        calendar.Meetings.Add(meeting);

        meeting = new Meeting
        {
            Id = Guid.NewGuid(),
            Title = "Lorem ipsum dolor sit amet.",
            Duration = 21,
            StartAt = DateTime.UtcNow.AddDays(2),
            CalendarId = calendar.Id
        };
        meeting.Reminders.Add(new Reminder
        {
            Id = Guid.NewGuid(),
            RemindBefore = 60,
            MeetingId = meeting.Id
        });
        meeting.Reminders.Add(new Reminder
        {
            Id = Guid.NewGuid(),
            RemindBefore = 30,
            MeetingId = meeting.Id
        });
        calendar.Meetings.Add(meeting);
        
        await context.Calendars.AddAsync(calendar, cancellationToken);

        /*
         * Add Ford's calendar.
         */
        calendar = new Calendar
        {
            Id = Guid.NewGuid(),
            Owner = "Ford Perfect",
            Type = "work",
            IsActive = true
        };

        meeting = new Meeting
        {
            Id = Guid.NewGuid(),
            Title = "Polish my friend Marvin",
            Description = "A really sad robot",
            Duration = 82,
            StartAt = DateTime.UtcNow.AddDays(-4),
            CalendarId = calendar.Id
        };
        meeting.Reminders.Add(new Reminder
        {
            Id = Guid.NewGuid(),
            RemindBefore = 20,
            MeetingId = meeting.Id
        });
        meeting.Reminders.Add(new Reminder
        {
            Id = Guid.NewGuid(),
            RemindBefore = 10,
            MeetingId = meeting.Id
        });
        calendar.Meetings.Add(meeting);

        meeting = new Meeting
        {
            Id = Guid.NewGuid(),
            Title = "Lorem ipsum dolor sit amet.",
            Duration = 164,
            StartAt = DateTime.UtcNow.AddDays(-2),
            CalendarId = calendar.Id
        };
        meeting.Reminders.Add(new Reminder
        {
            Id = Guid.NewGuid(),
            RemindBefore = 2,
            MeetingId = meeting.Id
        });
        meeting.Reminders.Add(new Reminder
        {
            Id = Guid.NewGuid(),
            RemindBefore = 1,
            MeetingId = meeting.Id
        });
        calendar.Meetings.Add(meeting);

        await context.Calendars.AddAsync(calendar, cancellationToken);

        /*
         * Add Marvin's calendar.
         */
        calendar = new Calendar
        {
            Id = Guid.NewGuid(),
            Owner = "Marvin",
            Type = "personal",
            IsActive = false
        };
        calendar.Meetings.Add(new Meeting
        {
            Id = Guid.NewGuid(),
            Title = "Meaning of life.",
            Description = "Clarify the meaning of life.",
            Duration = 2,
            StartAt = DateTime.UtcNow.AddDays(-2),
            CalendarId = calendar.Id
        });
        calendar.Meetings.Add(new Meeting
        {
            Id = Guid.NewGuid(),
            Title = "Lorem ipsum dolor sit amet.",
            Duration = 1,
            StartAt = DateTime.UtcNow.AddDays(-1),
            CalendarId = calendar.Id
        });
        await context.Calendars.AddAsync(calendar, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        Console.WriteLine("Inserting sample data ... done!");
    }
}