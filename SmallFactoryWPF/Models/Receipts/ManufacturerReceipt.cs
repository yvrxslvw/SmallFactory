namespace SmallFactoryWPF.Models
{
    public abstract class ManufacturerReceipt : Receipt
    {
        public readonly Part Material1;

        public readonly Part Material2;

        public readonly Part Material3;

        public readonly Part Material4;

        public readonly double Material1Rate;

        public readonly double Material2Rate;

        public readonly double Material3Rate;

        public readonly double Material4Rate;

        protected ManufacturerReceipt(
            Part material1,
            Part material2,
            Part material3,
            Part material4,
            double material1Rate,
            double material2Rate,
            double material3Rate,
            double material4Rate,
            Part resultPart,
            double productionRate) : base(resultPart, productionRate)
        {
            Material1 = material1;
            Material2 = material2;
            Material3 = material3;
            Material4 = material4;
            Material1Rate = material1Rate;
            Material2Rate = material2Rate;
            Material3Rate = material3Rate;
            Material4Rate = material4Rate;
        }
    }
}
