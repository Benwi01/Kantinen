using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IBAS_kantine.Models;
using Azure;

namespace IBAS_kantine.Pages;

public class IndexModel : PageModel
{
    private readonly TableClient _TableClient;

    public List<MenuItemDTO> MenuItems { get; set; } = new List<MenuItemDTO>();

    public IndexModel(TableClient tableClient)
    {
        _TableClient = tableClient;
    }

    public void OnGet()
    {
        Pageable<TableEntity> entities = _TableClient.Query<TableEntity>();

        foreach (var entity in entities)
        {
            MenuItems.Add(new MenuItemDTO
            {
                Dag = entity.GetString("RowKey"),
                Varmret = entity.GetString("Varmret"),
                Koldret = entity.GetString("Koldret")
            });

        }
    }
}
