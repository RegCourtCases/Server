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
    public class ThirdPartiesController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<ThirdPartiePOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ThirdPartiePOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<ThirdPartiePOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<ThirdPartiePOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<ThirdPartiePOCO>(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] ThirdPartiePOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.ThirdPartieId
            };
        }
    }
}
