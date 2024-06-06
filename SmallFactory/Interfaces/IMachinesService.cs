namespace SmallFactory.Interfaces
{
    public interface IMachinesService
    {
        public Task<string> MakeCycleAsync(int machineId);
    }
}
