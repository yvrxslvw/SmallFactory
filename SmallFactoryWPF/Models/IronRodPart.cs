namespace SmallFactoryWPF.Models
{
    public class IronRodPart : Part
    {
        public static decimal ShopPrice = 5;

        public static double ShopCooldown = 1;

        public static int ShopCount = 0;

        public IronRodPart() : base("Железный Прут") { }
    }
}
