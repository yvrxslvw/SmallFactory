namespace SmallFactoryWPF.Models
{
    public class CircuitBoardReceipt : AssemblerReceipt
    {
        public CircuitBoardReceipt() : base(
            material1: new CopperSheetPart(),
            material2: new PlasticPart(),
            material1Rate: 50,
            material2Rate: 100,
            resultPart: new CircuitBoardPart(),
            productionRate: 25)
        { }
    }
}
