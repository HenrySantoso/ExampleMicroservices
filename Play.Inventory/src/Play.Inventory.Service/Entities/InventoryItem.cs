using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Play.Common.Service;

namespace Play.Inventory.Service.Entities
{
    public class InventoryItem : IEntity
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; init; }
        public Guid UserId { get; set; }
        public Guid CatalogItemId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset AcquiredDate { get; set; }
    }
}
