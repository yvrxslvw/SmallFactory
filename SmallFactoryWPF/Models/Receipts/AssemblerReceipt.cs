namespace SmallFactoryWPF.Models
{
    public class AssemblerReceipt : ConstructorReceipt
    {

        public readonly Part Material2;

        public readonly int Material2Required;

        public AssemblerReceipt(
            Part material1,
            Part material2,
            int material1Required,
            int material2Required,
            Part resultPart,
            double productionRate,
            double cycleRate) : base(material1, material1Required, resultPart, productionRate, cycleRate)
        {
            Material2 = material2;
            Material2Required = material2Required;
        }
    }
}
