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
    public class ArticlesController : ControllerBase
    {
        [HttpGet("AllArticlesIds")]
        public async Task<IEnumerable<long>> GetAllIds()
        {
            return await DatabaseController.GetAllIds<ArticlePOCO>();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ArticlePOCO>> GetAll()
        {
            return await DatabaseController.GetAllEntries<ArticlePOCO>();
        }

        [HttpGet("Article")]
        public async Task<ArticlePOCO> Get([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<ArticlePOCO>(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEditActicle([FromBody] ArticlePOCO newArticle)
        {
            var inserted = await DatabaseController.InsertOrUpdate(newArticle);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = newArticle.ArticleId
            };
        }
    }
}
