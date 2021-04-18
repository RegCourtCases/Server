using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("Plaintiffs")]
    public class PlaintiffPOCO : PersonTypeBase
    {
        [AutoIncrement] public long PlaintiffId { get; set; }
    }
}
