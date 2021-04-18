using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("Productions")]
    public class ProductionPOCO
    {
        [AutoIncrement] public long ProductionId { get; set; }
        [Required] public long CourtCaseId { get; set; }
        [Required] public int TypeInstance { get; set; }
        [Required] public string NameCourt { get; set; }
        [Required] public string Judge { get; set; }
        [Required] public DateTime DateStatementClaim { get; set; }
        [Required] public DateTime DateInitiationProceedings { get; set; }
        public long? ClaimAmount { get; set; }
        public long? StateDuties { get; set; }
        [CustomField("LONGTEXT")] public string DescriptionClaim { get; set; }
        public int? SolutionType { get; set; }
        public long? AmountJudicialAct { get; set; }
        public DateTime? DateDecision { get; set; }
        public DateTime? DateEffectiveDecision { get; set; }
    }
}
