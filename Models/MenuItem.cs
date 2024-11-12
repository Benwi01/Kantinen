namespace IBAS_kantine.Models
{
    public record MenuItemDTO
    {
        public string Dag { get; set; }

        public string Varmret { get; set; }

        public string Koldret { get; set; }
    }
}
