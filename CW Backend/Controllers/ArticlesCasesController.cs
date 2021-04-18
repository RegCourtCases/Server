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
    public class ArticlesCasesController : ControllerBase
    {
        [HttpGet("AllIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<ArticlesCasePOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ArticlesCasePOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<ArticlesCasePOCO>();
        }

        [HttpGet("GetPlain")]
        public async Task<ArticlesCasePOCO> GetPlain([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<ArticlesCasePOCO>(id);
        }

        [HttpGet("Get")]
        public async Task<FullArticlesCasePOCO> Get([FromQuery] long id)
        {
            return await FullArticlesCasePOCO.Create(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEdit([FromBody] ArticlesCasePOCO entry)
        {
            var inserted = await DatabaseController.InsertOrUpdate(entry);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = entry.ArticlesCaseId
            };
        }
    }
}
