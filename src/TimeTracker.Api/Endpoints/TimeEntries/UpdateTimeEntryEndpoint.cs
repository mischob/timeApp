using FastEndpoints;
using TimeTracker.Shared.Models;

namespace TimeTracker.Api.Endpoints.TimeEntries;

public class UpdateTimeEntryRequest
{
    public Guid Id { get; set; }
    public required TimeEntry TimeEntry { get; set; }
}

public class UpdateTimeEntryEndpoint : Endpoint<UpdateTimeEntryRequest>
{
    public override void Configure()
    {
        Put("/api/time-entries/{Id}");
        AllowAnonymous(); // Will be replaced with proper auth later
        Description(d => d
            .WithName("UpdateTimeEntry")
            .Produces(204)
            .Produces(400)
            .Produces(404)
            .WithTags("TimeEntries"));
    }

    public override async Task HandleAsync(UpdateTimeEntryRequest req, CancellationToken ct)
    {
        if (req.Id != req.TimeEntry.Id) ThrowError("ID mismatch between route and body", 400);

        // This is a placeholder for future implementation
        req.TimeEntry.ModifiedAt = DateTime.Now;

        await SendNoContentAsync(ct);
    }
}