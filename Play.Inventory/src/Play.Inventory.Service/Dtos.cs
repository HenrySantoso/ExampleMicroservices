using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Play.Inventory.Service
{
    public class Dtos
    {
        public record GrantItemsDto(Guid UserId,Guid CatalogItemId, int Quantity);
        public record InventoryItemDto(Guid CatalogItemId, int Quantity, DateTimeOffset AcquiredDate);
    }
}