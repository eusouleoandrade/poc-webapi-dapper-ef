using System;

namespace PocWebApiDapperEf.Core.Domain.Entites
{
    public class Curva
    {
        public Guid Id { get; private set; }

        public string Description { get; private set; }

        public Curva(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public Curva(string description) : this(Guid.NewGuid(), description)
        {
        }
    }
}