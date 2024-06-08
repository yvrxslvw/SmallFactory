namespace SmallFactoryWPF.Models
{
    public class CableReceipt : ConstructorReceipt
    {
        public CableReceipt() : base(
            material1: new WirePart(),
            material1Rate: 45,
            resultPart: new CablePart(),
            productionRate: 22.5)
        { }
    }
}
