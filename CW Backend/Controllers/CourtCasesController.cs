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
    public class CourtCasesController : ControllerBase
    {
        [HttpGet("AllCourtCasesIds")]
        public async Task<IEnumerable<long>> GetAllCourtCasesIds()
        {
            return await DatabaseController.GetAllIds<CourtCasePOCO>();
        }

        [HttpGet("AllCourtCases")]
        public async Task<IEnumerable<CourtCasePOCO>> GetAllCourtCases()
        {
            return await DatabaseController.GetAllEntries<CourtCasePOCO>();
        }

        [HttpGet("PlainCourtCase")]
        public async Task<CourtCasePOCO> GetPlainCourtCase([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<CourtCasePOCO>(id);
        }

        [HttpGet("CourtCase")]
        public async Task<FullCourtCasePOCO> GetCourtCase([FromQuery] long id)
        {
            return await FullCourtCasePOCO.Create(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] CourtCasePOCO newCourtCase)
        {
            var inserted = await DatabaseController.InsertOrUpdate(newCourtCase);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = newCourtCase.CourtCaseId
            };
        }
    }
}
