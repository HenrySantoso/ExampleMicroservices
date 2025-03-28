using Microsoft.AspNetCore.Mvc;
using Play.Common.Service;
using Play.Inventory.Service.Entities;
using static Play.Inventory.Service.Dtos;

namespace Play.Inventory.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        public readonly IRepository<InventoryItem> itemRepository;

        public ItemsController(IRepository<InventoryItem> itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAsync()
        {
            var items = (await itemRepository.GetAllAsync()).Select(item => item.AsDto());
            return Ok(items);
        }

        [HttpGet("{id}", Name = "GetByIdAsync")]
        public async Task<ActionResult<InventoryItemDto>> GetByIdAsync(Guid id)
        {
            var item = await itemRepository.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

        public async Task<ActionResult<InventoryItemDto>> PostAsync(GrantItemsDto grantItemsDto)
        {
            var inventoryItem = await itemRepository.GetByIdAsync(grantItemsDto.UserId);
            if (inventoryItem is null)
            {
                inventoryItem = new InventoryItem
                {
                    UserId = grantItemsDto.UserId,
                    CatalogItemId = grantItemsDto.CatalogItemId,
                    Quantity = grantItemsDto.Quantity,
                    AcquiredDate = DateTimeOffset.UtcNow
                };
                await itemRepository.CreateAsync(inventoryItem);
            }
            else
            {
                inventoryItem.Quantity += grantItemsDto.Quantity;
                await itemRepository.UpdateAsync(inventoryItem);
            }
            return Ok();
        }
    }
}
