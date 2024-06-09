namespace SmallFactoryWPF.Models
{
    public class ScrewReceipt : ConstructorReceipt
    {
        public ScrewReceipt() : base(
            material1: new IronRodPart(),
            material1Rate: 32.5,
            resultPart: new ScrewPart(),
            productionRate: 130)
        { }
    }
}
