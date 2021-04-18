using CW_Backend.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.Controllers
{
    public interface IBaseController
    {
        public Task<IEnumerable<long>> GetAllIds();
        public Task<T> GetPlain<T>([FromQuery] long id);
        public Task<CreateOrEditDTO> CreateOrEditActicle<T>([FromBody] T entry);
    }
}
