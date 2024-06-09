namespace SmallFactoryWPF.Models
{
    public abstract class Receipt
    {
        public readonly Part ResultPart;

        public readonly double ProductionRate;

        public readonly double CycleRate;

        protected Receipt(Part resultPart, double productionRate, double cycleRate)
        {
            ResultPart = resultPart;
            ProductionRate = productionRate;
            CycleRate = cycleRate;
        }
    }
}
