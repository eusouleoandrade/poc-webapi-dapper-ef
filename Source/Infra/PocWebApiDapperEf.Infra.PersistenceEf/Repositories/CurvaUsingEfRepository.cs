using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PocWebApiDapperEf.Core.Application.Interfaces;
using PocWebApiDapperEf.Core.Domain.Entites;
using PocWebApiDapperEf.Infra.PersistenceEf.Contexts;

namespace PocWebApiDapperEf.Infra.PersistenceEf.Repositories
{
    public class CurvaUsingEfRepository : ICurvaUsingEfRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CurvaUsingEfRepository(ApplicationDbContext dbContext)
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }

        public void DeleteAll()
        {
            try
            {
                _dbContext.RemoveRange(GetAll());
                _dbContext.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}