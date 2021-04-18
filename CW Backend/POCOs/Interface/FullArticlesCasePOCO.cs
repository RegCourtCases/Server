using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs.Interface
{
    public class FullArticlesCasePOCO
    {
        public static async Task<FullArticlesCasePOCO> Create(long id)
        {
            var entry = await DatabaseController.GetEntry<ArticlesCasePOCO>(id);
            return new FullArticlesCasePOCO
            {
                ArticlesCaseId = entry.ArticlesCaseId,
                CourtCaseId = entry.CourtCaseId,
                ArticleId = entry.ArticleId,
                Article = (await DatabaseController.GetEntriesByPredicate<ArticlePOCO>(x => x.ArticleId == entry.ArticleId)).FirstOrDefault()
            };
        }

        public long ArticlesCaseId { get; set; }
        public long CourtCaseId { get; set; }
        public long ArticleId { get; set; }
        public ArticlePOCO Article { get; set;}
    }
}
