using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ODataSample.Library.Database;
using ODataSample.Library.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

var connectionString = configuration.GetConnectionString("Default");
services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

services.AddScoped<ICalendarRepository, CalendarRepository>();
services.AddScoped<IMeetingRepository, MeetingRepository>();
services.AddScoped<IReminderRepository, ReminderRepository>();

services.AddControllers()
    .AddJsonOptions(options =>
        // Preserve = Metadata properties will be honored when deserializing JSON objects and
        //            arrays into reference types and written when serializing reference types.
        //            This is necessary to create round-trippable JSON from objects that contain
        //            cycles or duplicate references.
        // IgnoreCycles = Ignores an object when a reference cycle is detected during serialization.
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    )
    .AddOData(options =>
    {
        options.Select();
        options.OrderBy();
        options.Filter();
        options.Expand();
        options.SetMaxTop(100);
    });

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var application = builder.Build();

var updater = DatabaseUpdater.Create(application);
await updater.RunAsync();

if (application.Environment.IsDevelopment())
{
    application.UseSwagger();
    application.UseSwaggerUI();
}

application.UseHttpsRedirection();
application.UseAuthorization();
application.MapControllers();

application.Run();
