namespace TimeTracker.Shared.Models;

public class TimeEntry
{
    public Guid Id { get; set; }
    public required string UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public TimeSpan Duration => EndTime - StartTime;
    public bool IsManualEntry { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string SyncStatus { get; set; } = "Pending";
}