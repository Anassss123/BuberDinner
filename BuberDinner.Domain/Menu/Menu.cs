using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Domain.Common.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinners = new();
        private readonly List<MenuReviewId> _menuReviews = new();
        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; } 
        public IReadOnlyList<DinnerId> Dinners => _dinners.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviews => _menuReviews.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }    
        
        private Menu(MenuId menuId, string name, string description, float averageRating, List<MenuSection> sections ,HostId hostId, DateTime createdDateTime, DateTime updatedDateTime) : base(menuId)
        {
            Name = name;
            Description = description;
            AverageRating = 0;
            _sections= sections;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        
        public static Menu Create(string name, string description, float averageRating,  List<MenuSection> sections, HostId hostId)
        {
            return new(MenuId.CreateUnique(), name , description, averageRating, sections, hostId , DateTime.UtcNow , DateTime.UtcNow);
        }   
    }
}