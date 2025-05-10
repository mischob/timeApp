using FastEndpoints;
using TimeTracker.Shared.Models;

namespace TimeTracker.Api.Endpoints.TimeEntries;

public class GetAllTimeEntriesEndpoint : Endpoint<EmptyRequest, List<TimeEntry>>
{
    public override void Configure()
    {
        Get("/api/time-entries");
        AllowAnonymous(); // Will be replaced with proper auth later
        Description(d => d
            .WithName("GetTimeEntries")
            .Produces<List<TimeEntry>>(200, "application/json")
            .WithTags("TimeEntries"));
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        // This is a placeholder for future implementation
        var timeEntries = new List<TimeEntry>
        {
            new()
            {
                Id = Guid.NewGuid(),
                UserId = "sample-user",
                StartTime = DateTime.Now.AddHours(-2),
                EndTime = DateTime.Now.AddHours(-1),
                IsManualEntry = false,
                CreatedAt = DateTime.Now,
                SyncStatus = "Synced"
            }
        };

        await SendAsync(timeEntries, cancellation: ct);
    }
}