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
    public class DocumentsController : ControllerBase
    {
        [HttpGet("AllDocumentsIds")]
        public async Task<IEnumerable<long>> GetAllPersonsIds()
        {
            return await DatabaseController.GetAllIds<DocumentPOCO>();
        }

        [HttpGet("AllDocuments")]
        public async Task<IEnumerable<DocumentPOCO>> GetAllPersons()
        {
            return await DatabaseController.GetAllEntries<DocumentPOCO>();
        }

        [HttpGet("PlainDocument")]
        public async Task<DocumentPOCO> GetPlainDocument([FromQuery] long id)
        {
            return await DatabaseController.GetEntry<DocumentPOCO>(id);
        }

        [HttpGet("Document")]
        public async Task<FullDocumentPOCO> GetDocument([FromQuery] long id)
        {
            return await FullDocumentPOCO.Create(id);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<CreateOrEditDTO> CreateOrEditDocument([FromBody] DocumentPOCO newDocument)
        {
            var inserted = await DatabaseController.InsertOrUpdate(newDocument);
            return new CreateOrEditDTO
            {
                Inserted = inserted,
                Id = newDocument.DocumentId
            };
        }
    }
}
