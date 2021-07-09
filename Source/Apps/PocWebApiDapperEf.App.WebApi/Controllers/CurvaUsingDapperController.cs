using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PocWebApiDapperEf.Core.Application.Interfaces;
using PocWebApiDapperEf.Core.Domain.Entites;

namespace PocWebApiDapperEf.App.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurvaUsingDapperController : ControllerBase
    {
        private readonly ICurvaUsingDapperService _curvaService;

        public CurvaUsingDapperController(ICurvaUsingDapperService curvasService)
        {
            _curvaService = curvasService;
        }

         [HttpGet]
        public ActionResult<IReadOnlyList<Curva>> Get()
        {
            return Ok(_curvaService.GetAll());
        }

        [HttpPost]
        public ActionResult Post(int insertNumber)
        {
            for (int i = 1; i <= insertNumber; i++)
            {
                var curva = new Curva($"Curva - {i}");
                _curvaService.Add(curva);
            }
            
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            _curvaService.DeleteAll();
            return Ok();
        }
    }
}