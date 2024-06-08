namespace SmallFactoryWPF.Models
{
    public class ComputerPart : Part
    {
        public static decimal ShopPrice = 42;

        public static double ShopCooldown = 0;

        public static int ShopCount = 0;

        public ComputerPart() : base("Компьютер") { }
    }
}
