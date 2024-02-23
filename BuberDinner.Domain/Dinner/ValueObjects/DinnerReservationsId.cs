using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public sealed class DinnerReservationsId : ValueObject
    {
        public Guid Value { get; }
        private DinnerReservationsId(Guid value)
        {
            Value = value;
        }
        public static DinnerReservationsId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}