using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.Contracts.Menus
{
    public record MenuResponse 
    {
        public string Id { get; init; }= default!;
        public string Name { get; init; }= default!;
        public string Description { get; init; }= default!;
        public float? AverageRating { get; init; }= default!;
        public List<MenuSectionResponse> Sections { get; init; }= default!;
        public string HostId { get; init; }= default!;
        public List<string> DinnerIds { get; init; }= default!;
        public List<string> MenuReviewIds { get; init; }= default!;
        public DateTime CreatedDateTime { get; init; }= default!;
        public DateTime UpdatedDateTime { get; init; }= default!;

        public MenuResponse() { }
        public MenuResponse(string id, string name, string description, float? averageRating, List<MenuSectionResponse> sections, string hostId, List<string> dinnerIds, List<string> menuReviewIds, DateTime createdDateTime, DateTime updatedDateTime)
        {
            Id = id;
            Name = name;
            Description = description;
            AverageRating = averageRating;
            Sections = sections;
            HostId = hostId;
            DinnerIds = dinnerIds;
            MenuReviewIds = menuReviewIds;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
    }
    
    public record MenuSectionResponse
    (
        string Id,
        string Name,
        string Description,
        List<MenuItemResponse> Items
    );
    public record MenuItemResponse 
    (
        string Id,
        string Name,
        string Description
    );
}