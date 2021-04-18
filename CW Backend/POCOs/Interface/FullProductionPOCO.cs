using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs.Interface
{
    public class FullProductionPOCO
    {
        public static async Task<FullProductionPOCO> Create(long id)
        {
            var entry = await DatabaseController.GetEntry<ProductionPOCO>(id);
            return new FullProductionPOCO
            {
                ProductionId = entry.ProductionId,
                CourtCaseId = entry.CourtCaseId,
                TypeInstance = entry.TypeInstance,
                NameCourt = entry.NameCourt,
                Judge = entry.Judge,
                DateStatementClaim = entry.DateStatementClaim,
                DateInitiationProceedings = entry.DateInitiationProceedings,
                ClaimAmount = entry.ClaimAmount,
                StateDuties = entry.StateDuties,
                DescriptionClaim = entry.DescriptionClaim,
                SolutionType = entry.SolutionType,
                AmountJudicialAct = entry.AmountJudicialAct,
                DateDecision = entry.DateDecision,
                DateEffectiveDecision = entry.DateEffectiveDecision,
                Plaintiffs = await DatabaseController.GetEntriesByPredicate<PlaintiffPOCO>(x => x.ProductionId == id),
                Respondents = await DatabaseController.GetEntriesByPredicate<RespondentPOCO>(x => x.ProductionId == id),
                InterestedParties = await DatabaseController.GetEntriesByPredicate<InterestedPartiePOCO>(x => x.ProductionId == id),
                ThirdParties = await DatabaseController.GetEntriesByPredicate<ThirdPartiePOCO>(x => x.ProductionId == id)
            };
        }

        public long ProductionId { get; set; }
        public long CourtCaseId { get; set; }
        public int TypeInstance { get; set; }
        public string NameCourt { get; set; }
        public string Judge { get; set; }
        public DateTime DateStatementClaim { get; set; }
        public DateTime DateInitiationProceedings { get; set; }
        public long? ClaimAmount { get; set; }
        public long? StateDuties { get; set; }
        public string DescriptionClaim { get; set; }
        public int? SolutionType { get; set; }
        public long? AmountJudicialAct { get; set; }
        public DateTime? DateDecision { get; set; }
        public DateTime? DateEffectiveDecision { get; set; }
        public IEnumerable<PlaintiffPOCO> Plaintiffs { get; set; }
        public IEnumerable<RespondentPOCO> Respondents { get; set; }
        public IEnumerable<InterestedPartiePOCO> InterestedParties { get; set; }
        public IEnumerable<ThirdPartiePOCO> ThirdParties { get; set; }
    }
}
