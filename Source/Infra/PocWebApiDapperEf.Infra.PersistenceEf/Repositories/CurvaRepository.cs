using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PocWebApiDapperEf.Core.Application.Interfaces;
using PocWebApiDapperEf.Core.Domain.Entites;
using PocWebApiDapperEf.Infra.PersistenceEf.Contexts;

namespace PocWebApiDapperEf.Infra.PersistenceEf.Repositories
{
    public class CurvaRepository : ICurvaUsingEfRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CurvaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Curva entity)
        {
            try
            {
                _dbContext.Set<Curva>().Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new System.NotImplementedException();
            }
        }

        public IReadOnlyList<Curva> GetAll()
        {
            try
            {
                return _dbContext.Set<Curva>().ToListAsync().Result;
            }
            catch (Exception)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}