namespace SmallFactoryWPF.Models
{
    public class PlasticPart : Part
    {
        public static decimal ShopPrice = 6;

        public static double ShopCooldown = 1;

        public static int ShopCount = 0;

        public PlasticPart() : base("Пластик") { }
    }
}
