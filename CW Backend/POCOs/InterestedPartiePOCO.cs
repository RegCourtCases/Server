using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("InterestedParties")]
    public class InterestedPartiePOCO : PersonTypeBase
    {
        [AutoIncrement] public long InterestedPartieId { get; set; }
    }
}
