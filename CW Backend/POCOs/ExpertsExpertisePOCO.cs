using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("ExpertsExpertises")]
    public class ExpertsExpertisePOCO
    {
        [AutoIncrement] public long ExpertsExpertiseId { get; set; }
        [Required] public long ExpertiseId { get; set; }
        [Required] public long PersonId { get; set; }
    }
}
