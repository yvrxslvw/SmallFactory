namespace SmallFactoryWPF.Models
{
    public class ManufacturerReceipt : AssemblerReceipt
    {

        public readonly Part Material3;

        public readonly Part Material4;

        public readonly int Material3Required;

        public readonly int Material4Required;

        public ManufacturerReceipt(
            Part material1,
            Part material2,
            Part material3,
            Part material4,
            int material1Required,
            int material2Required,
            int material3Required,
            int material4Required,
            Part resultPart,
            double productionRate,
            double cycleRate) : base(material1, material2, material1Required, material2Required, resultPart, productionRate, cycleRate)
        {
            Material3 = material3;
            Material4 = material4;
            Material3Required = material3Required;
            Material4Required = material4Required;
        }
    }
}
