namespace SmallFactoryWPF.Models
{
    public abstract class Receipt
    {
        public readonly Part ResultPart;

        public readonly double ProductionRate;

        protected Receipt(Part resultPart, double productionRate)
        {
            ResultPart = resultPart;
            ProductionRate = productionRate;
        }
    }
}
