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
    public class PlaintiffsController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<PlaintiffPOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<PlaintiffPOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<PlaintiffPOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<PlaintiffPOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<PlaintiffPOCO>(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] PlaintiffPOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.PlaintiffId
            };
        }
    }
}
