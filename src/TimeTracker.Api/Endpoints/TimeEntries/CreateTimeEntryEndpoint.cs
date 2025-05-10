using FastEndpoints;
using TimeTracker.Shared.Models;

namespace TimeTracker.Api.Endpoints.TimeEntries;

public class CreateTimeEntryEndpoint : Endpoint<TimeEntry, TimeEntry>
{
    public override void Configure()
    {
        Post("/api/time-entries");
        AllowAnonymous(); // Will be replaced with proper auth later
        Description(d => d
            .WithName("CreateTimeEntry")
            .Produces<TimeEntry>(201, "application/json")
            .WithTags("TimeEntries"));
    }

    public override async Task HandleAsync(TimeEntry req, CancellationToken ct)
    {
        // This is a placeholder for future implementation
        req.Id = Guid.NewGuid();
        req.CreatedAt = DateTime.Now;

        await SendCreatedAtAsync<GetTimeEntryByIdEndpoint>(
            new { req.Id },
            req,
            generateAbsoluteUrl: true,
            cancellation: ct);
    }
}