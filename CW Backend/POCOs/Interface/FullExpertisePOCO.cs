using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs.Interface
{
    public class FullExpertisePOCO
    {
        public static async Task<FullExpertisePOCO> Create(long id)
        {
            var entry = await DatabaseController.GetEntry<ExpertisePOCO>(id);
            return new FullExpertisePOCO
            {
                ExpertiseId = entry.ExpertiseId,
                ArticleId = entry.ArticleId,
                CourtCaseId = entry.CourtCaseId,
                Question = entry.Question,
                FileLink = entry.FileLink,
                DateConclusion = entry.DateConclusion,
                ConclusionStatus = entry.ConclusionStatus,
                Article = (await DatabaseController.GetEntriesByPredicate<ArticlePOCO>(x => x.ArticleId == entry.ArticleId)).FirstOrDefault(),
            };
        }

        public long ExpertiseId { get; set; }
        public long ArticleId { get; set; }
        public long CourtCaseId { get; set; }
        public string Question { get; set; }
        public string FileLink { get; set; }
        public DateTime DateConclusion { get; set; }
        public string ConclusionStatus { get; set; }
        public ArticlePOCO Article { get; set; }
    }
}
