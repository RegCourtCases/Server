using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("CourtCases")]
    public class CourtCasePOCO
    {
        [AutoIncrement] public long CourtCaseId { get; set; }
        [Required] public int TypeCase { get; set; }
        [Required] public int TypeLegalProceedings { get; set; }
        [Required] public DateTime DateReceiptPrimaryDocument { get; set; }
        public int? BasisIntroductionCriminalCase { get; set; }
        public DateTime? DateProductionEnd { get; set; }
        public DateTime? DateEffectiveDecision { get; set; }
        public string SubjectDispute { get; set; }
        public string BasisDispute { get; set; }
        public int? ResultDispute { get; set; }
        public int? DirectionDispute { get; set; }
    }
}
