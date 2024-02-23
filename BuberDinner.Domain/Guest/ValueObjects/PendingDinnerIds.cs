using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects
{
    public class PendingDinnersIds : ValueObject
    {
        public Guid Value { get; }
        private PendingDinnersIds(Guid value)
        {
            Value = value;
        }
        public static PendingDinnersIds CreateUnique()
        {
            return new(Guid.NewGuid());
        }
         public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}