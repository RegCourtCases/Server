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
    public class ExpertisesController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<ExpertisePOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ExpertisePOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<ExpertisePOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<ExpertisePOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<ExpertisePOCO>(id);
        }

        [HttpGet("Get")]
        public async Task<FullExpertisePOCO> Get([FromQuery] long id)
        {
            return await FullExpertisePOCO.Create(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] ExpertisePOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.ExpertiseId
            };
        }
    }
}
