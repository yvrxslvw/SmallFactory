namespace SmallFactoryWPF.Models
{
    public class CopperSheetPart : Part
    {
        public static decimal ShopPrice = 10;

        public static double ShopCooldown = 1;

        public static int ShopCount = 0;

        public CopperSheetPart() : base("Медный Лист") { }
    }
}
