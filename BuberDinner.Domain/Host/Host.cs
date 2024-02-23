using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Host
{
    public class Host : AggregateRoot<HostId>
    {
        private readonly List<MenuId> _menus = new();
        private readonly List<DinnerId> _dinners = new();
        public string FirstName { get;}
        public string LastName { get;}
        public Guid UserId { get; }
        public string ProfileImage { get;}
        public decimal AverageRating { get; }
        public IReadOnlyList<MenuId> Menus => _menus.AsReadOnly();
        public IReadOnlyList<DinnerId> Dinners => _dinners.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        private Host(HostId hostId, string firstName, string lastName, Guid userId , string profileImage, decimal averageRating , DateTime createdDateTime, DateTime updatedDateTime) : base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public static Host Create(string firstName, string lastName, Guid userId , string profileImage, decimal averageRating , DateTime createdDateTime, DateTime updatedDateTime)
        {
            return new(HostId.CreateUnique(),  firstName,  lastName,  userId ,  profileImage,  averageRating ,  createdDateTime,  updatedDateTime);
        } 
    }
}