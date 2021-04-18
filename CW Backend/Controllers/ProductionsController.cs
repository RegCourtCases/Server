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
    public class ProductionsController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<ProductionPOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ProductionPOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<ProductionPOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<ProductionPOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<ProductionPOCO>(id);
        }

        [HttpGet("Get")]
        public async Task<FullProductionPOCO> Get([FromQuery] long id)
        {
            return await FullProductionPOCO.Create(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] ProductionPOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.ProductionId
            };
        }
    }
}
