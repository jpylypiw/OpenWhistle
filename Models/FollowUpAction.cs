namespace OpenWhistle.Models;

public class FollowUpAction : BaseEntity
{
    public string ActionDescription { get; set; }
    public WhistleblowerReport Report { get; set; }
}