namespace TimeTracker.Shared.Models;

public class WeeklySummary
{
    public int Year { get; set; }
    public int Week { get; set; }
    public TimeSpan TotalHours { get; set; }
    public TimeSpan TargetHours => TimeSpan.FromHours(16);
    public TimeSpan Overtime => TotalHours - TargetHours;
}