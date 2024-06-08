namespace SmallFactoryWPF.Models
{
    public class CircuitBoardPart : Part
    {
        public static decimal ShopPrice = 18;

        public static double ShopCooldown = 0;

        public static int ShopCount = 0;

        public CircuitBoardPart() : base("Печатная Плата") { }
    }
}
