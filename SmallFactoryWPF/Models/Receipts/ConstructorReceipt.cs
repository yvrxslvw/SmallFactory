namespace SmallFactoryWPF.Models
{
    public class ConstructorReceipt : Receipt
    {
        public readonly Part Material1;

        public readonly int Material1Required;

        public ConstructorReceipt(
            Part material1,
            int material1Required,
            Part resultPart,
            double productionRate,
            double cycleRate) : base(resultPart, productionRate, cycleRate)
        {
            Material1 = material1;
            Material1Required = material1Required;
        }
    }
}
