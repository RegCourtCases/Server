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
    public class InspectorsCasesController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<InspectorsCasePOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<InspectorsCasePOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<InspectorsCasePOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<InspectorsCasePOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<InspectorsCasePOCO>(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] InspectorsCasePOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.InspectorsCaseId
            };
        }
    }
}
