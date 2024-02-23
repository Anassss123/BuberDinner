using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview
{
    public class MenuReview : AggregateRoot<MenuReviewId>
    {
        public int Rating { get; }
        public string Comment {get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public GuestId GuestId { get; }
        public DinnerId DinnerId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public MenuReview(MenuReviewId id , int rating , string comment, HostId hostId ,MenuId menuId, GuestId guestId, DinnerId dinnerId, DateTime createdDateTime, DateTime updatedDateTime ) : base(id)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            HostId = hostId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;

        }
        public static MenuReview Create(int rating , string comment, HostId hostId ,MenuId menuId, GuestId guestId, DinnerId dinnerId, DateTime createdDateTime, DateTime updatedDateTime)
        {
            return new(MenuReviewId.CreateUnique(),  rating ,  comment,  hostId , menuId,  guestId,  dinnerId,  createdDateTime,  updatedDateTime);
        }
    }
}