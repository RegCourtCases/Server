using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("ThirdParties")]
    public class ThirdPartiePOCO : PersonTypeBase
    {
        [AutoIncrement] public long ThirdPartieId { get; set; }
    }
}
