using SmallFactory.DTOs;
using SmallFactory.Models;

namespace SmallFactory.Interfaces
{
    public interface IMachinesRepository
    {
        public Task<List<Machine>> GetMachinesAsync();
        public Task<Machine> GetMachineByIdAsync(int id);
        public Task<Machine> CreateMachineAsync(CreateMachineDto createMachineDto);
        public Task<Machine> UpdateMachineAsync(int id, UpdateMachineDto updateMachineDto);
        public Task DeleteMachineAsync(int id);
    }
}
