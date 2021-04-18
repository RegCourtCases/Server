using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    public class PersonTypeBase
    {
        [Required] public long ProductionId { get; set; }
        [Required] public long PersonId { get; set; }
    }
}
