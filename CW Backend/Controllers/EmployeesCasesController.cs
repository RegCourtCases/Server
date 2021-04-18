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
    public class EmployeesCasesController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<EmployeesCasePOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<EmployeesCasePOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<EmployeesCasePOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<EmployeesCasePOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<EmployeesCasePOCO>(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] EmployeesCasePOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.EmployeesCaseId
            };
        }
    }
}
