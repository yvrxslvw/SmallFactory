namespace SmallFactoryWPF.Models
{
    public class WirePart : Part
    {
        public static decimal ShopPrice = 7;

        public static double ShopCooldown = 1;

        public static int ShopCount = 0;

        public WirePart() : base("Проволока") { }
    }
}
