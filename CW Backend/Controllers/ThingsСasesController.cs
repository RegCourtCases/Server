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
    public class ThingsCasesController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<ThingsCasePOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ThingsCasePOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<ThingsCasePOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<ThingsCasePOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<ThingsCasePOCO>(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] ThingsCasePOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.ThingCaseId
            };
        }
    }
}
