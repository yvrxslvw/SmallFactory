namespace SmallFactoryWPF.Models
{
    public class ScrewPart : Part
    {
        public static decimal ShopPrice = 2;

        public static double ShopCooldown = 0;

        public static int ShopCount = 0;

        public ScrewPart() : base("Винт") { }
    }
}
