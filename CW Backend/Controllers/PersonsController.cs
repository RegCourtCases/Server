using CW_Backend.DTO;
using CW_Backend.POCOs;
using CW_Backend.POCOs.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpGet("AllPersonsIds")]
        public async Task<IEnumerable<long>> GetAllPersonsIds()
        {
            return await DatabaseController.GetAllIds<PersonPOCO>();
        }

        [HttpGet("AllPersons")]
        public async Task<IEnumerable<PersonPOCO>> GetAllPersons()
        {
            return await DatabaseController.GetAllEntries<PersonPOCO>();
        }

        [HttpGet("Person")]
        public async Task<FullPersonPOCO> GetPerson([FromQuery] long id)
        {
            return await FullPersonPOCO.Create(id, true);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEditPerson([FromBody] PersonPOCO newPerson)
        {
            var inserted = await DatabaseController.InsertOrUpdate(newPerson);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = newPerson.PersonId
            };
        }

        [HttpGet("PersonCourtCases")]
        public async Task<List<CourtCasePOCO>> GetPersonCurtCases([FromQuery] long id)
        {
            var thingsСases = await DatabaseController.GetEntriesByPredicate<ThingsCasePOCO>(x => x.OwnerId == id);
            var expertExpertisesIds = (await DatabaseController.GetEntriesByPredicate<ExpertsExpertisePOCO>(x => x.PersonId == id)).Select(x => x.ExpertiseId).Distinct();
            var plaintiffs = await DatabaseController.GetEntriesByPredicate<PlaintiffPOCO>(x => x.PersonId == id);
            var respondents = await DatabaseController.GetEntriesByPredicate<RespondentPOCO>(x => x.PersonId == id);
            var interestedParties = await DatabaseController.GetEntriesByPredicate<InterestedPartiePOCO>(x => x.PersonId == id);
            var thirdParties = await DatabaseController.GetEntriesByPredicate<ThirdPartiePOCO>(x => x.PersonId == id);

            var expertises = new List<ExpertisePOCO>();
            foreach (var expertExpertiseId in expertExpertisesIds)
                expertises.Add(await DatabaseController.GetEntry<ExpertisePOCO>(expertExpertiseId));

            var allProdIds = new List<long>();
            allProdIds.AddRange(plaintiffs.Select(x => x.ProductionId));
            allProdIds.AddRange(respondents.Select(x => x.ProductionId));
            allProdIds.AddRange(interestedParties.Select(x => x.ProductionId));
            allProdIds.AddRange(thirdParties.Select(x => x.ProductionId));
            var uniqueProdIds = allProdIds.Distinct();

            var allProds = new List<ProductionPOCO>();
            foreach (var prodId in uniqueProdIds)
                allProds.Add(await DatabaseController.GetEntry<ProductionPOCO>(prodId));

            var CourtCasesIds = new List<long>();
            CourtCasesIds.AddRange(thingsСases.Select(x => x.CourtCaseId));
            CourtCasesIds.AddRange(expertises.Select(x => x.CourtCaseId));
            CourtCasesIds.AddRange(allProds.Select(x => x.CourtCaseId));
            var uniqueCourtCasesIds = CourtCasesIds.Distinct(); 

            var result = new List<CourtCasePOCO>();
            foreach (var cCId in uniqueCourtCasesIds)
                result.Add(await DatabaseController.GetEntry<CourtCasePOCO>(cCId));

            return result;
        }
    }
}
