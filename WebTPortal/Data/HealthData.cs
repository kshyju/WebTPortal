using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;
using WebTPortal.Models;

namespace WebTPortal.Data
{
    public class HealthData : IHealthData
    {
        public HealthData(IOptions<AppSettings> options)
        {
            connecitonStr = options.Value.ConnectionString;
        }
        private readonly string connecitonStr;
               


        public IEnumerable<RunItem> GetRunsForSite(int siteId)
        {
            var q = @"
SELECT   [RunId] ,
        MIN(StartTime) StartTime,
         COUNT(1) CallCount
FROM     [dbo].[NetworkCall] WITH ( NOLOCK ) WHERE SiteId=2
GROUP BY RunId";
            using (var c = new SqlConnection(connecitonStr))
            {
                return c.Query<RunItem>(q, new { siteId });
            }
        }
        public IEnumerable<NetworkCall> GetCallsForRun(int runId,int siteId)
        {
            var q = "SELECT * from NetworkCall WITH (NOLOCK) WHERE RunId=@runId and SiteId=@siteId";
            using (var c = new SqlConnection(connecitonStr))
            {
                return c.Query<NetworkCall>(q, new { runId, siteId });
            }
        }
        public IEnumerable<NetworkCall> GetCallsForUrl(string url)
        {
            var q = "SELECT * from NetworkCall WITH (NOLOCK) WHERE Url=@url ORDER BY StartTime DESC";
            using (var c = new SqlConnection(connecitonStr))
            {
                return c.Query<NetworkCall>(q, new { url });
            }
        }
    }
}