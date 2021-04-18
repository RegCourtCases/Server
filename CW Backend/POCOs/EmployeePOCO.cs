using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("Employees")]
    public class EmployeePOCO
    {
        [AutoIncrement] public long EmployeeId { get; set; }
        [Required] public long PersonId { get; set; }
        [Required] public string Post { get; set; }
    }
}
