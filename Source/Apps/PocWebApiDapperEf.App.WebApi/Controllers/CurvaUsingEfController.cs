using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PocWebApiDapperEf.Core.Application.Interfaces;
using PocWebApiDapperEf.Core.Domain.Entites;

namespace PocWebApiDapperEf.App.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurvaUsingEfController : ControllerBase
    {
        private readonly ICurvaUsingEfService _curvaServive;

        public CurvaUsingEfController(ICurvaUsingEfService curvaService)
        {
            _curvaServive = curvaService;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<Curva>> Get()
        {
            return Ok(_curvaServive.GetAll());
        }

        [HttpPost]
        public ActionResult Post(int insertNumber)
        {
            for (int i = 1; i <= insertNumber; i++)
            {
                var curva = new Curva($"Curva - {i}");
                _curvaServive.Add(curva);
            }
            
            return Ok();
        }
    }
}