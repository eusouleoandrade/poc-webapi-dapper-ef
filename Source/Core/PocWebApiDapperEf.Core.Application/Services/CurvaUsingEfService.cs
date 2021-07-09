using System.Collections.Generic;
using PocWebApiDapperEf.Core.Application.Interfaces;
using PocWebApiDapperEf.Core.Domain.Entites;

namespace PocWebApiDapperEf.Core.Application.Services
{
    public class CurvaUsingEfService : ICurvaUsingEfService
    {
        private readonly ICurvaUsingEfRepository _curvaRepository;

        public CurvaUsingEfService(ICurvaUsingEfRepository curvaRepository)
        {
            _curvaRepository = curvaRepository;
        }

        public void Add(Curva entity)
        {
            _curvaRepository.Add(entity);
        }

        public IReadOnlyList<Curva> GetAll()
        {
            return _curvaRepository.GetAll();
        }

        public void DeleteAll()
        {
            _curvaRepository.DeleteAll();
        }
    }
}