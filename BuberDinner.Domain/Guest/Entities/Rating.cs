using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using ErrorOr;

namespace BuberDinner.Domain.Guest.Entities
{
    public class Ratings : Entity<RatingId>
    {
        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public int Rating { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        private Ratings(RatingId ratingId, HostId hostId, DinnerId dinnerId, int rating, DateTime createdDateTime, DateTime updatedDateTime) : base(ratingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            Rating = rating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            
        }
        public static Ratings Create(HostId hostId, DinnerId dinnerId, int rating, DateTime createdDateTime, DateTime updatedDateTime)
        {
            return new(RatingId.CreateUnique(), hostId , dinnerId, rating, createdDateTime, updatedDateTime);
        }
    }
}