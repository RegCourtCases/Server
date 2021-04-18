using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("ArticlesCases")]
    public class ArticlesCasePOCO
    {
        [AutoIncrement] public long ArticlesCaseId { get; set; }
        [Required] public long CourtCaseId { get; set; }
        [Required] public long ArticleId { get; set; }
    }
}
