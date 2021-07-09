using System.Collections.Generic;
using PocWebApiDapperEf.Core.Application.Interfaces;
using PocWebApiDapperEf.Core.Domain.Entites;
using System;
using Npgsql;
using Dapper;
using System.Linq;

namespace PocWebApiDapperEf.Infra.PersistenceDapper.Repositories
{
    public class CurvaUsingDapperRepository : ICurvaUsingDapperRespository, IDisposable
    {
        private const string _connectionString = "Host=127.0.0.1;Port=5432;Pooling=true;Database=FK6DB;User Id=postgres;Password=postgres@21;";

        private readonly NpgsqlConnection _connection;

        public CurvaUsingDapperRepository()
        {
            _connection = new NpgsqlConnection(_connectionString);
        }

        public void Add(Curva entity)
        {
            try
            {
                var insertEntity = "INSERT INTO public.\"Curvas\" VALUES (@Id, @Description)";

                _connection.Execute(insertEntity, new
                {
                    Id = entity.Id,
                    Description = entity.Description
                });
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
                var deleteAllEntity = "DELETE FROM public.\"Curvas\"";

                _connection.Execute(deleteAllEntity);
            }
            catch (System.Exception)
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }

        public IReadOnlyList<Curva> GetAll()
        {
            try
            {
                var query = "SELECT \"Id\", \"Description\" FROM public.\"Curvas\"";
                var curvas = _connection.Query<Curva>(query);
                return curvas.ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}