using System.Runtime.InteropServices.JavaScript;

namespace OpenWhistle.Models;

public class BaseAuditableEntity : BaseEntity
{
    public DateTime DateCreated { get; } = DateTime.UtcNow;
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    public DateTime LastStatusUpdate { get; set; } = DateTime.UtcNow;
    //TODO: To entity?
    public string CreatedBy { get; set; }
    public string LastModifiedBy { get; set; }
}