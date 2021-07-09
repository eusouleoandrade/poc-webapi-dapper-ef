using System.Collections.Generic;
using PocWebApiDapperEf.Core.Domain.Entites;

namespace PocWebApiDapperEf.Core.Application.Interfaces
{
    public interface ICurvaUsingEfService
    {
        IReadOnlyList<Curva> GetAll();

        void Add(Curva entity);

        void DeleteAll();
    }
}