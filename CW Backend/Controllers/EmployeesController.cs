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
    public class EmployeesController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<EmployeePOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<EmployeePOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<EmployeePOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<EmployeePOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<EmployeePOCO>(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] EmployeePOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.EmployeeId
            };
        }
    }
}
