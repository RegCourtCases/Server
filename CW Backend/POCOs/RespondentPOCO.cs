using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("Respondents")]
    public class RespondentPOCO : PersonTypeBase
    {
        [AutoIncrement] public long RespondentId { get; set; }
    }
}
