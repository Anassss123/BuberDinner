using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects
{
    public class PastDinnersIds : ValueObject
    {
        public Guid Value { get; }
        private PastDinnersIds(Guid value)
        {
            Value = value;
        }
        public static PastDinnersIds CreateUnique()
        {
            return new(Guid.NewGuid());
        }
         public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}