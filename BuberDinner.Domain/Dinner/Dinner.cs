using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entity;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;

namespace BuberDinner.Domain.Dinner
{
    public class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<DinnerReservations> _reservations = new();
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime {get;}
        public DateTime EndDateTime {get;}
        public DateTime StartedDateTime {get;}
        public DateTime EndedDateTime {get;}
        public string Status {get; }
        public bool IsPublic {get;}
        public int MaxGuests {get;}
        public Price Price {get; } = null!;
        public HostId HostId{get; }
        public MenuId MenuId{get; }
        public string ImageURL {get; }
        public Location Location {get; }
        public IReadOnlyList<DinnerReservations> Reservations => _reservations.AsReadOnly();
        public DateTime CreatedDateTime {get;}
        public DateTime UpdatedDateTime {get;}

        private Dinner(
            DinnerId dinnerId,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime startedDateTime,
            DateTime endedDateTime,
            string status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageURL,
            Location location,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(dinnerId)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            StartedDateTime = startedDateTime;
            EndedDateTime = endedDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            HostId = hostId;
            MenuId = menuId;
            ImageURL = imageURL;
            Location = location;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public static Dinner Create(
            string name, 
            string description, 
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime startedDateTime,
            DateTime endedDateTime,
            string status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageURL,
            Location location,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            return new(
                DinnerId.CreateUnique(),
                name , 
                description, 
                startDateTime,
                endDateTime, 
                startedDateTime , 
                endedDateTime, 
                status,
                isPublic,
                maxGuests,
                price,
                hostId,
                menuId,
                imageURL,
                location,
                createdDateTime,
                updatedDateTime);
        }
    }
}