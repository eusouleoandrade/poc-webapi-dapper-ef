using System.Collections.Generic;
using PocWebApiDapperEf.Core.Application.Interfaces;
using PocWebApiDapperEf.Core.Domain.Entites;

namespace PocWebApiDapperEf.Core.Application.Services
{
    public class CurvaUsingDapperService : ICurvaUsingDapperService
    {
        private readonly ICurvaUsingDapperRespository _curvaRepository;

        public CurvaUsingDapperService(ICurvaUsingDapperRespository curvaRepository)
        {
            _curvaRepository = curvaRepository;
        }

        public void Add(Curva entity)
        {
            _curvaRepository.Add(entity);
        }

        public void DeleteAll()
        {
            _curvaRepository.DeleteAll();
        }

        public IReadOnlyList<Curva> GetAll()
        {
            return _curvaRepository.GetAll();
        }
    }
}