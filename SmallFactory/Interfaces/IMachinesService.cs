using SmallFactory.DTOs;

namespace SmallFactory.Interfaces
{
    public interface IMachinesService
    {
        public Task<string> MakeCycleAsync(MakeMachineCycleDto makeMachineCycleDto);
    }
}
