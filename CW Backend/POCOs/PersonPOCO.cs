using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("Persons")]
    public class PersonPOCO
    {
        [AutoIncrement] public long PersonId { get; set; }
        public string ShortName { get; set; }
        [Required, System.ComponentModel.DataAnnotations.Required] public string FullName { get; set; }
        public string Address { get; set; }
        [StringLength(12)] public string TIN { get; set; }
        [Required, System.ComponentModel.DataAnnotations.Required] public bool IsLegal { get; set; }
        [StringLength(12), Unique] public string PassportData { get; set; }
        public DateTime? DateBirth { get; set; } = null;
        [Ignore] public string DateTimeStr { get; set; }
    }
}
