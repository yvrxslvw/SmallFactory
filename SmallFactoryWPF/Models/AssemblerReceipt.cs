namespace SmallFactoryWPF.Models
{
    public abstract class AssemblerReceipt : Receipt
    {
        public readonly Part Material1;

        public readonly Part Material2;

        public readonly double Material1Rate;

        public readonly double Material2Rate;

        protected AssemblerReceipt(
            Part material1,
            Part material2,
            double material1Rate,
            double material2Rate,
            Part resultPart,
            double productionRate) : base(resultPart, productionRate)
        {
            Material1 = material1;
            Material2 = material2;
            Material1Rate = material1Rate;
            Material2Rate = material2Rate;
        }
    }
}
