using CW_Backend.DTO;
using CW_Backend.POCOs;
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
    public class CaseParticipantsController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<CaseParticipantPOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<CaseParticipantPOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<CaseParticipantPOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<CaseParticipantPOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<CaseParticipantPOCO>(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] CaseParticipantPOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.CaseParticipantId
            };
        }
    }
}
