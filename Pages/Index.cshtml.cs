
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OpenWhistle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DashboardModel(ILogger<DashboardModel> logger) : PageModel
{
    private readonly ILogger<DashboardModel> _logger = logger;

    public int OpenReportsCount { get; set; }
    public int UnopenedReportsCount { get; set; }
    public int ConfirmedReceptionCount { get; set; }
    public int ReportsWithoutActionsCount { get; set; }

    public List<WhistleblowerReport> UpcomingDeadlines { get; set; }
    public List<WhistleblowerReport> HistoryItems { get; set; }
    public List<WhistleblowerReport> Reports { get; set; }

    public async Task OnGetAsync()
    {
        var reports = await GetReports();

        OpenReportsCount = reports.Count(r => r.Status == ReportStatus.Read);
        UnopenedReportsCount = reports.Count(r => r.Status == ReportStatus.Received);
        ConfirmedReceptionCount = reports.Count(r => r.Status == ReportStatus.Acknowledged);
        ReportsWithoutActionsCount = reports.Count(r => r.Status == ReportStatus.ActionTaken);

        UpcomingDeadlines = reports.Where(r => r.Deadline <= DateTime.Now.AddMonths(3)).OrderBy(r => r.Deadline).ToList();
        HistoryItems = reports.OrderByDescending(r => r.DateCreated).Take(5).ToList();
        Reports = reports;
    }

    private Task<List<WhistleblowerReport>> GetReports()
    {
        return Task.FromResult(new List<WhistleblowerReport>
        {
            new("Review submission") ,
            new("Provide feedback") ,
            new("Final approval") ,
            new("Final approval"){ Description = "Initial review", AssignedTo = "John Doe"},
            new("Final approval") { Description = "Secondary review", AssignedTo = "Jane Doe" }
        });
    }
}