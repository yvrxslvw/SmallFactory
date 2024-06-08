namespace SmallFactoryWPF.Models
{
    public abstract class Part
    {
        public readonly string Name;

        public static decimal ShopPrice;

        public static double ShopCooldown;

        public static int ShopCount;

        protected Part(string name, decimal shopPrice, double shopCooldown)
        {
            Name = name;
            ShopPrice = shopPrice;
            ShopCooldown = shopCooldown;
            ShopCount = 0;
        }
    }
}
