using System;
using System.Collections.Generic;

namespace WebTPortal.Models
{
    public class SiteDetails
    {
        public string SiteName { get; set; }
        public IEnumerable<RunItem> Calls { set; get; }
    }

    public class RunItem
    {
        public int RunId { set; get; }
        public int CallCount { set; get; }

        public string DisplayType { set; get; }
        public DateTime StartTime { set; get; }
    }

    public class UrlRunDetails
    {
        public string Url { set; get; }
        public IEnumerable<NetworkCall> Calls { set; get; }

    }
    public class RunDetailsVm : RunItem
    {
        public IEnumerable<NetworkCall> Calls { set; get; }
    }


public class NetworkCall
    {
        public int Id { set; get; }
        public string Url { set; get; }
        public int Duration { set; get; }
        public DateTime StartTime { set; get; }


        public string Initiator { set; get; }

        /// <summary>
        /// GEt or POST
        /// </summary>
        public string Method { set; get; }
        /// <summary>
        /// Response status code (Ex : 200/302)
        /// </summary>
        public int Status { set; get; }

        public int? SiteId { set; get; }

        /// <summary>
        /// Type of resrouce (Ex : xhr/image/script)
        /// </summary>
        public string ResourceType { set; get; }
    }
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}