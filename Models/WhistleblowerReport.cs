namespace OpenWhistle.Models;

public class WhistleblowerReport(string description) : BaseEntity
{
    public bool IsAssigned { get; set; }= false;
    public string AssignedTo { get; set; }
    public string Description { get; init; } = description;
    public DateTime Deadline
    {
        get
        {
            switch (Status)
            {
                case ReportStatus.Acknowledged:
                    return DateCreated.AddMonths(3);
                case ReportStatus.Received: 
                case ReportStatus.Read:
                    return DateCreated.AddDays(7);
                default:
                    return DateCreated.AddDays(7);
            }
        }
    }

    public ReportStatus Status { get; set; } = ReportStatus.Received;
}