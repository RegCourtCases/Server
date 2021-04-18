using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs.Interface
{
    public class FullDocumentPOCO
    {
        public static async Task<FullDocumentPOCO> Create(long id)
        {
            var entry = await DatabaseController.GetEntry<DocumentPOCO>(id);
            var result = new FullDocumentPOCO
            {
                DocumentId = entry.DocumentId,
                IsCaseArticle = entry.IsCaseArticle,
                IsExpertise = entry.IsExpertise,
                FullTitle = entry.FullTitle,
                ShortTitle = entry.ShortTitle,
                Articles = await DatabaseController.GetEntriesByPredicate<ArticlePOCO>(x => x.DocumentId == id)
            };
            return result;
        }

        public long DocumentId { get; set; }
        public bool IsCaseArticle { get; set; }
        public bool IsExpertise { get; set; }
        public string FullTitle { get; set; }
        public string ShortTitle { get; set; }
        public IEnumerable<ArticlePOCO> Articles { get; set; }
    }
}
