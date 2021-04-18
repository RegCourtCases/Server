using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("Articles")]
    public class ArticlePOCO
    {
        [AutoIncrement] public long ArticleId { get; set; }
        [Required, Index, System.ComponentModel.DataAnnotations.Required] public long DocumentId { get; set; }
        [Required, System.ComponentModel.DataAnnotations.Required] public string Title { get; set; }
        [Required, CustomField("LONGTEXT"), System.ComponentModel.DataAnnotations.Required] public string Text { get; set; }
        public string ExpertiseClass { get; set; }
    }
}
