using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.Users;

namespace BuberDinner.Domain.Guest
{
    public class Guest : AggregateRoot<GuestId>
    {
        private readonly List<UpcomingDinnerIds> _upcomingDinners = new();
        private readonly List<PastDinnersIds> _pastDinners = new();
        private readonly List<PendingDinnersIds> _pendingDinners = new();
        private readonly List<BillId> _bills = new();
        private readonly List<MenuReviewId> _menuReviews = new();
        private readonly List<RatingId> _ratings = new();
        public string FirstName { get;}
        public string LastName { get;}
        public Guid UserId { get; }
        public string ProfileImage { get;}
        public decimal AverageRating { get; }
        public IReadOnlyList<UpcomingDinnerIds> UpcomingDinners => _upcomingDinners.AsReadOnly();
        public IReadOnlyList<PastDinnersIds> PastDinners => _pastDinners.AsReadOnly();
        public IReadOnlyList<PendingDinnersIds> PendingDinners => _pendingDinners.AsReadOnly();
        public IReadOnlyList<BillId> Bills => _bills.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviews => _menuReviews.AsReadOnly();
        public IReadOnlyList<RatingId> Ratings => _ratings.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        private Guest(GuestId id, string firstName, string lastName, Guid userId , string profileImage, decimal averageRating , DateTime createdDateTime, DateTime updatedDateTime) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public static Guest Create(string firstname, string lastName, Guid userId , string profileImage, decimal averageRating , DateTime createdDateTime, DateTime updatedDateTime)
        {
            return new(GuestId.CreateUnique(), firstname,  lastName,  userId ,  profileImage,  averageRating ,  createdDateTime,  updatedDateTime);
        }   
    }
}
