namespace SmallFactoryWPF.Models
{
    public abstract class ConstructorReceipt : Receipt
    {
        public readonly Part Material1;

        public readonly double Material1Rate;

        protected ConstructorReceipt(
            Part material1,
            double material1Rate,
            Part resultPart,
            double productionRate) : base(resultPart, productionRate)
        {
            Material1 = material1;
            Material1Rate = material1Rate;
        }
    }
}
