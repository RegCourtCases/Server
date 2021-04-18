using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("Documents")]
    public class DocumentPOCO
    {
        [AutoIncrement] public long DocumentId { get; set; }
        [Required, System.ComponentModel.DataAnnotations.Required] public bool IsCaseArticle { get; set; }
        [Required, System.ComponentModel.DataAnnotations.Required] public bool IsExpertise { get; set; }
        [Required, System.ComponentModel.DataAnnotations.Required] public string FullTitle { get; set; }
        public string ShortTitle { get; set; }
    }
}
