namespace SmallFactoryWPF.Models
{
    public class ComputerReceipt : ManufacturerReceipt
    {
        public ComputerReceipt() : base(
            material1: new ScrewPart(),
            material2: new CircuitBoardPart(),
            material3: new CablePart(),
            material4: new PlasticPart(),
            material1Rate: 130,
            material2Rate: 25,
            material3Rate: 22.5,
            material4Rate: 45,
            resultPart: new ComputerPart(),
            productionRate: 2.5)
        { }
    }
}
