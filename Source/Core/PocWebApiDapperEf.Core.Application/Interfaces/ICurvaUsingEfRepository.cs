using System.Collections.Generic;
using PocWebApiDapperEf.Core.Domain.Entites;

namespace PocWebApiDapperEf.Core.Application.Interfaces
{
    public interface ICurvaUsingEfRepository
    {
         void Add(Curva entity);

         IReadOnlyList<Curva> GetAll();
    }
}