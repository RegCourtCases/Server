using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("EmployeesCases")]
    public class EmployeesCasePOCO
    {
        [AutoIncrement] public long EmployeesCaseId { get; set; }
        [Required] public long CourtCaseId { get; set; }
        [Required] public long EmployeeId { get; set; }
    }
}
