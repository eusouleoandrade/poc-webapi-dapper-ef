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
            var curvaTeste = new Curva("Curva Teste");
            _curvaServive.Add(curvaTeste);
            return Ok(_curvaServive.GetAll());
        }
    }
}