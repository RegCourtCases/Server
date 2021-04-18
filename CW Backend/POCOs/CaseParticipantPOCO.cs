using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("CaseParticipants")]
    public class CaseParticipantPOCO
    {
        [AutoIncrement] public long CaseParticipantId { get; set; }
        [Required] public long CourtCaseId { get; set; }
        [Required] public long PersonId { get; set; }
        [Required] public int Role { get; set; }
        [Required] public string PlaceWork { get; set; }
    }
}
