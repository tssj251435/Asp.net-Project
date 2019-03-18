using System.Collections.Generic;

namespace FindGavenCore.Models
{
    public class IndexViewModel
    {
        public string HeadLine { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPrevPage { get; set; }
        public bool PopHasNextPage { get; set; }
        public bool PopHasPrevPage { get; set; }
        public List<string> DistinctOccasion { get; set; }
        public List<string> DistinctCategory { get; set; }
        public List<string> DistinctWho { get; set; }
        public List<Present> PopularPresents { get; set; } = new List<Present>();
        public List<Present> PresentsResults { get; set; } = new List<Present>();
        public List<Present> PresentResultsLimit { get; set; } = new List<Present>();
        
        public Provider Provider { get; set; }
        
    }
}