using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("Expertises")]
    public class ExpertisePOCO
    {
        [AutoIncrement] public long ExpertiseId { get; set; }
        [Required] public long ArticleId { get; set; }
        [Required] public long CourtCaseId { get; set; }
        [Required, CustomField("LONGTEXT")] public string Question { get; set; }
        [Required] public string FileLink { get; set; }
        [Required] public DateTime DateConclusion { get; set; }
        [Required] public string ConclusionStatus { get; set; }
    }
}
