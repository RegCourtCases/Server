using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("InspectorsCases")]
    public class InspectorsCasePOCO
    {
        [AutoIncrement] public long InspectorsCaseId { get; set; }
        [Required] public long CourtCaseId { get; set; }
        [Required] public long PersonId { get; set; }
    }
}
