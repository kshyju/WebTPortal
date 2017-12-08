using System.Collections.Generic;
using WebTPortal.Models;

namespace WebTPortal.Data
{
    public interface IHealthData
    {
        IEnumerable<NetworkCall> GetCallsForRun(int runId, int siteId);
        IEnumerable<NetworkCall> GetCallsForUrl(string url);
        IEnumerable<RunItem> GetRunsForSite(int siteId);
    }
}