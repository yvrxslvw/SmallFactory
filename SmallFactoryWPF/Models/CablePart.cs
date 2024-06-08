namespace SmallFactoryWPF.Models
{
    public class CablePart : Part
    {
        public static decimal ShopPrice = 8;

        public static double ShopCooldown = 0;

        public static int ShopCount = 0;

        public CablePart() : base("Кабель") { }
    }
}
