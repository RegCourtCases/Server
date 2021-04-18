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
    public class InterestedPartiesController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<InterestedPartiePOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<InterestedPartiePOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<InterestedPartiePOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<InterestedPartiePOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<InterestedPartiePOCO>(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] InterestedPartiePOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.InterestedPartieId
            };
        }
    }
}
