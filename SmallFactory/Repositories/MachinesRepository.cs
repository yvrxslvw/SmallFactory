﻿using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Repositories
{
    public class MachinesRepository(MachinesContext machinesContext, ProductionChainsContext productionChainsContext, ReceiptsContext receiptsContext) : IMachinesRepository
    {
        private readonly MachinesContext _machinesContext = machinesContext;
        private readonly ProductionChainsContext _productionChainsContext = productionChainsContext;
        private readonly ReceiptsContext _receiptsContext = receiptsContext;

        public async Task<Machine> CreateMachineAsync(CreateMachineDto createMachineDto)
        {
            if (await _productionChainsContext.ProductionChains.FirstOrDefaultAsync(pc => pc.Id == createMachineDto.ProductionChainId) == null)
                throw new ApiException(404, "Производственной цепочки с таким ID не существует.");
            if (await _receiptsContext.Receipts.FirstOrDefaultAsync(r => r.Id == createMachineDto.ReceiptId) == null)
                throw new ApiException(404, "Рецепта с таким ID не существует.");
            Machine machine = new()
            {
                ProductionChainId = createMachineDto.ProductionChainId,
                Type = (MachineTypes)createMachineDto.Type,
                ReceiptId = createMachineDto.ReceiptId,
                StorageId = -1, // to delete
            };
            _machinesContext.Machines.Add(machine);
            await Save();
            return machine;

        }

        public async Task DeleteMachineAsync(int id)
        {
            Machine? machine = await _machinesContext.Machines.FirstOrDefaultAsync(m => m.Id == id);
            if (machine == null)
                throw new ApiException(404, "Станка с таким ID не существует.");
            _machinesContext.Machines.Remove(machine);
            await Save();
        }

        public async Task<Machine> GetMachineByIdAsync(int id)
        {
            Machine? machine = await _machinesContext.Machines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (machine == null)
                throw new ApiException(404, "Станка с таким ID не существует.");
            return machine;
        }

        public async Task<List<Machine>> GetMachinesAsync()
        {
            List<Machine> machines = await _machinesContext.Machines
                .OrderBy(m => m.Id)
                .ToListAsync();
            return machines;
        }

        public async Task<Machine> UpdateMachineAsync(int id, UpdateMachineDto updateMachineDto)
        {
            Machine? machine = await _machinesContext.Machines.FirstOrDefaultAsync(m => m.Id == id);
            if (machine == null)
                throw new ApiException(404, "Станка с таким ID не существует.");
            if (updateMachineDto.Type != null)
            {
                machine.Type = (MachineTypes)updateMachineDto.Type;
            }
            if (updateMachineDto.ReceiptId != null)
            {
                if (await _receiptsContext.Receipts.FirstOrDefaultAsync(r => r.Id == updateMachineDto.ReceiptId) == null)
                    throw new ApiException(404, "Рецепта с таким ID не существует.");
                machine.ReceiptId = (int)updateMachineDto.ReceiptId;
            }
            await Save();
            return machine;
        }

        private async Task Save()
        {
            int result = await _machinesContext.SaveChangesAsync();
            if (result == 0)
                throw new ApiUnexpectedException();
        }
    }
}