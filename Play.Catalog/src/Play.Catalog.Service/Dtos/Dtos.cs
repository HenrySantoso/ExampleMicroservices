using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Dtos
{
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
    public record CreateItemDto(string Name, string Description,[Range(0,1000)] decimal Price);
    public record UpdateItemDto(string Name, string Description,[Range(0,1000)] decimal Price);
}