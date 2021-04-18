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
    public class EpisodesController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<EpisodePOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<EpisodePOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<EpisodePOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<EpisodePOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<EpisodePOCO>(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] EpisodePOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.EpisodeId
            };
        }
    }
}
