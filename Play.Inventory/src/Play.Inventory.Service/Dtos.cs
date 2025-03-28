namespace Play.Inventory.Service
{
    public class Dtos
    {
        public record GrantItemsDto(Guid UserId, Guid CatalogItemId, int Quantity);

        public record InventoryItemDto(
            Guid CatalogItemId,
            String Name,
            String Description,
            int Quantity,
            DateTimeOffset AcquiredDate
        );

        public record CatalogItemDto(Guid Id, String Name, String Description);
    }
}
