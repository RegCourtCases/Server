using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("ThingsCases")]
    public class ThingsCasePOCO
    {
        [AutoIncrement] public long ThingCaseId { get; set; }
        [Required] public long CourtCaseId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public long OwnerId { get; set; }
        public string Description { get; set; }
        [Required] public string StorageLocation { get; set; }
        public string FileLink { get; set; }
    }
}
