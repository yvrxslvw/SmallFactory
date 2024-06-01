namespace SmallFactory.DTOs
{
    public class ShopItemDto
    {
        public int Id { get; set; }

        public int PartId { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public int CoolDown { get; set; }
    }
}
