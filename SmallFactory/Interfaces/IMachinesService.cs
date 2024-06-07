namespace SmallFactory.Interfaces
{
    public interface IMachinesService
    {
        public Task MakeCycleAsync(int machineId);
        public Task Manufacturing();
    }
}
