namespace SmallFactory.DTOs
{
    public class CreateShopItemDto
    {
        public int PartId { get; set; }

        public decimal Price { get; set; }

        public int CoolDown { get; set; }
    }
}
