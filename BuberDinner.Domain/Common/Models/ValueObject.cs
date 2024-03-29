using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Common.Models
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }
            var valueObject = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }
        public static bool operator ==(ValueObject left , ValueObject  right )
        {
            return Equals(left,right);
        }
        public static bool operator !=(ValueObject left , ValueObject  right )
        {
            return !Equals(left,right);
        }
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                    .Select(x => x?.GetHashCode() ?? 0)
                    .Aggregate((x,y)=> x ^ y);
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }
    }
    public class Price : ValueObject
    {
        public decimal Amount {get ; private set;}
        public decimal Currency {get ; private set;}
        public Price (decimal amount, decimal currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return  Currency;
        }
    }
    public class Location : ValueObject
    {
        public string Name {get ; private set;}
        public string Address {get ; private set;}
        public float Laltitude {get ; private set;}
        public float Longitude {get ; private set;}
        public Location (string name, string address, float laltitude, float longitude)
        {
            Name = name;
            Address = address;
            Laltitude = laltitude;
            Longitude = longitude; 
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
            yield return Laltitude;
            yield return Longitude;
        }
    }
}