using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("Episodes")]
    public class EpisodePOCO
    {
        [AutoIncrement] public long EpisodeId { get; set; }
        [Required] public long CourtCaseId { get; set; }
        [Required] public string WorkingTitle { get; set; }
        [Required] public string CategoryCrime { get; set; }
        [Required] public string TypeCrime { get; set; }
        [Required] public DateTime DateStartCrime { get; set; }
        [Required] public DateTime DateEndCrime { get; set; }
        [Required] public string PlaceCrime { get; set; }
        public string PurposeCrime { get; set; }
        public string ToolCrime { get; set; }
        public string Notes { get; set; }
    }
}
