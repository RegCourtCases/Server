using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs.Interface
{
    public class FullCourtCasePOCO
    {
        public static async Task<FullCourtCasePOCO> Create(long id)
        {
            var entry = await DatabaseController.GetEntry<CourtCasePOCO>(id);

            var preArticlesCasesIds = (await DatabaseController.GetEntriesByPredicate<ArticlesCasePOCO>(x => x.CourtCaseId == id)).Select(x => x.ArticlesCaseId);
            var articlesCases = new List<FullArticlesCasePOCO>();
            foreach (var pId in preArticlesCasesIds)
                articlesCases.Add(await FullArticlesCasePOCO.Create(pId));

            var preExpertisesIds = (await DatabaseController.GetEntriesByPredicate<ExpertisePOCO>(x => x.CourtCaseId == id)).Select(x => x.ExpertiseId);
            var expertises = new List<FullExpertisePOCO>();
            foreach (var pId in preExpertisesIds)
                expertises.Add(await FullExpertisePOCO.Create(pId));

            var preProductionsIds = (await DatabaseController.GetEntriesByPredicate<ProductionPOCO>(x => x.CourtCaseId == id)).Select(x => x.ProductionId);
            var productions = new List<FullProductionPOCO>();
            foreach (var pId in preProductionsIds)
                productions.Add(await FullProductionPOCO.Create(pId));

            return new FullCourtCasePOCO
            {
                CourtCaseId = entry.CourtCaseId,
                TypeCase = entry.TypeCase,
                TypeLegalProceedings = entry.TypeLegalProceedings,
                DateReceiptPrimaryDocument = entry.DateReceiptPrimaryDocument,
                BasisIntroductionCriminalCase = entry.BasisIntroductionCriminalCase,
                DateProductionEnd = entry.DateProductionEnd,
                DateEffectiveDecision = entry.DateEffectiveDecision,
                SubjectDispute = entry.SubjectDispute,
                BasisDispute = entry.BasisDispute,
                ResultDispute = entry.ResultDispute,
                DirectionDispute = entry.DirectionDispute,
                Productions = productions,
                Expertises = expertises,
                ThingsCases = await DatabaseController.GetEntriesByPredicate<ThingsCasePOCO>(x => x.CourtCaseId == id),
                CaseParticipants = await DatabaseController.GetEntriesByPredicate<CaseParticipantPOCO>(x => x.CourtCaseId == id),
                ArticlesCases = articlesCases,
                InspectorsCases = await DatabaseController.GetEntriesByPredicate<InspectorsCasePOCO>(x => x.CourtCaseId == id),
                EmployeesCases = await DatabaseController.GetEntriesByPredicate<EmployeesCasePOCO>(x => x.CourtCaseId == id),
                Episodes = await DatabaseController.GetEntriesByPredicate<EpisodePOCO>(x => x.CourtCaseId == id)
            };
        }
        public long CourtCaseId { get; set; }
        public int TypeCase { get; set; }
        public int TypeLegalProceedings { get; set; }
        public DateTime DateReceiptPrimaryDocument { get; set; }
        public int? BasisIntroductionCriminalCase { get; set; }
        public DateTime? DateProductionEnd { get; set; }
        public DateTime? DateEffectiveDecision { get; set; }
        public string SubjectDispute { get; set; }
        public string BasisDispute { get; set; }
        public int? ResultDispute { get; set; }
        public int? DirectionDispute { get; set; }
        public IEnumerable<FullProductionPOCO> Productions { get; set; }
        public IEnumerable<FullExpertisePOCO> Expertises { get; set; }
        public IEnumerable<ThingsCasePOCO> ThingsCases { get; set; }
        public IEnumerable<CaseParticipantPOCO> CaseParticipants { get; set; }
        public IEnumerable<FullArticlesCasePOCO> ArticlesCases { get; set; }
        public IEnumerable<InspectorsCasePOCO> InspectorsCases { get; set; }
        public IEnumerable<EmployeesCasePOCO> EmployeesCases { get; set; }
        public IEnumerable<EpisodePOCO> Episodes { get; set; }
    }
}
