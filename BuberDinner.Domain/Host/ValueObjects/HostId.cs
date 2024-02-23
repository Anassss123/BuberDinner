using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;

namespace BuberDinner.Domain.Host.ValueObjects
{
    public class HostId : ValueObject
    {
        public Guid Value { get; }
        private HostId(Guid value)
        {
            Value = value;
        }
    public static HostId Create(string value)
    {
        if (!Guid.TryParse(value, out Guid guidValue))
        {
            throw new ArgumentException("Invalid GUID value.");
        }
        return new HostId(guidValue);
    }
    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }
         public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}