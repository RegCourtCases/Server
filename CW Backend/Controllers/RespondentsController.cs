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
    public class RespondentsController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<RespondentPOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<RespondentPOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<RespondentPOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<RespondentPOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<RespondentPOCO>(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] RespondentPOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.RespondentId
            };
        }
    }
}
