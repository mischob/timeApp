using FastEndpoints;

namespace TimeTracker.Api.Endpoints.TimeEntries;

public class DeleteTimeEntryRequest
{
    public Guid Id { get; set; }
}

public class DeleteTimeEntryEndpoint : Endpoint<DeleteTimeEntryRequest>
{
    public override void Configure()
    {
        Delete("/api/time-entries/{Id}");
        AllowAnonymous(); // Will be replaced with proper auth later
        Description(d => d
            .WithName("DeleteTimeEntry")
            .Produces(204)
            .Produces(404)
            .WithTags("TimeEntries"));
    }

    public override async Task HandleAsync(DeleteTimeEntryRequest req, CancellationToken ct)
    {
        // This is a placeholder for future implementation
        // In a real implementation, we would delete the entry from the database

        await SendNoContentAsync(ct);
    }
}