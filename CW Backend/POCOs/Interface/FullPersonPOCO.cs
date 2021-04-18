using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs.Interface
{
    public class FullPersonPOCO
    {
        public static async Task<Dictionary<string, PersonTypeBase>> GetPersonTypes(long id)
        {
            var result = new Dictionary<string, PersonTypeBase>();
            var plaintiff = await DatabaseController.GetEntry<PlaintiffPOCO>(id);
            if (plaintiff != null)
                result.Add("plaintiff", plaintiff);
            var respondent = await DatabaseController.GetEntry<RespondentPOCO>(id);
            if (respondent != null)
                result.Add("respondent", respondent);
            var interestedPartie = await DatabaseController.GetEntry<InterestedPartiePOCO>(id);
            if (interestedPartie != null)
                result.Add("interestedPartie", interestedPartie);
            var thirdParties = await DatabaseController.GetEntry<ThirdPartiePOCO>(id);
            if (plaintiff != null)
                result.Add("thirdParties", thirdParties);

            return result;
        }

        public static async Task<FullPersonPOCO> Create(long id, bool getPersonTypes = false)
        {
            var person = await DatabaseController.GetEntry<PersonPOCO>(id);
            var result = new FullPersonPOCO
            {
                PersonId = person.PersonId,
                ShortName = person.ShortName,
                FullName = person.FullName,
                Address = person.Address,
                TIN = person.TIN,
                IsLegal = person.IsLegal,
                PassportData = person.PassportData,
                DateBirth = person.DateBirth,
                personTypes = getPersonTypes ? await GetPersonTypes(id) : null
            };
            return result;
        }

        public long PersonId { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string TIN { get; set; }
        public bool IsLegal { get; set; }
        public string PassportData { get; set; }
        public DateTime? DateBirth { get; set; }
        public Dictionary<string, PersonTypeBase> personTypes { get; set; }
    }
}
