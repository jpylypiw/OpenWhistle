using Microsoft.EntityFrameworkCore;

namespace OpenWhistle.Models
{
    public interface IOpenWhistleDbContext
    {
        DbSet<WhistleblowerReport> Reports { get; }
        DbSet<FollowUpAction> FollowUpActions { get; }
    }

    public class OpenWhistleDbContext(DbContextOptions<OpenWhistleDbContext> options)
        : DbContext(options), IOpenWhistleDbContext
    {
        public DbSet<WhistleblowerReport> Reports { get; set; }
        public DbSet<FollowUpAction> FollowUpActions { get; set; }
    }
}