using FastEndpoints;
using TimeTracker.Shared.Models;

namespace TimeTracker.Api.Endpoints.TimeEntries;

public class GetTimeEntryByIdRequest
{
    public Guid Id { get; set; }
}

public class GetTimeEntryByIdEndpoint : Endpoint<GetTimeEntryByIdRequest, TimeEntry>
{
    public override void Configure()
    {
        Get("/api/time-entries/{Id}");
        AllowAnonymous(); // Will be replaced with proper auth later
        Description(d => d
            .WithName("GetTimeEntryById")
            .Produces<TimeEntry>(200, "application/json")
            .Produces(404)
            .WithTags("TimeEntries"));
    }

    public override async Task HandleAsync(GetTimeEntryByIdRequest req, CancellationToken ct)
    {
        // This is a placeholder for future implementation
        var timeEntry = new TimeEntry
        {
            Id = req.Id,
            UserId = "sample-user",
            StartTime = DateTime.Now.AddHours(-2),
            EndTime = DateTime.Now.AddHours(-1),
            IsManualEntry = false,
            CreatedAt = DateTime.Now,
            SyncStatus = "Synced"
        };

        await SendAsync(timeEntry, cancellation: ct);
    }
}