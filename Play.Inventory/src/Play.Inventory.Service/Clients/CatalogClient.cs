using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Play.Inventory.Service.Dtos;

namespace Play.Inventory.Service.Clients
{
    public class CatalogClient
    {
        private readonly HttpClient httpClient;

        public CatalogClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<CatalogItemDto>> GetCatalogItemsAsync()
        {
            var items = await httpClient.GetFromJsonAsync<IReadOnlyCollection<CatalogItemDto>>(
                "/api/Items"
            );
            return items ?? Array.Empty<CatalogItemDto>();
        }
    }
}
