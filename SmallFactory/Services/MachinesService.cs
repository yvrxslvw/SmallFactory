﻿using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Services
{
    public class MachinesService(AppDbContext context) : IMachinesService
    {
        private readonly AppDbContext _context = context;

        public async Task MakeCycleAsync(int machineId)
        {
            Machine? machine = await _context.Machines
                .Include(m => m.Receipt)
                .Include(m => m.ProductionChain)
                .FirstOrDefaultAsync(m => m.Id == machineId);
            if (machine == null)
                throw new ApiException(404, "Станка с таким ID не существует.");

            Receipt receipt = (await _context.Receipts
                .Include(r => r.ManufacturedPart)
                .Include(r => r.Material1Part)
                .Include(r => r.Material2Part)
                .Include(r => r.Material3Part)
                .Include(r => r.Material4Part)
                .FirstOrDefaultAsync(r => r.Id == machine.ReceiptId))!;
            int factoryId = machine.ProductionChain.FactoryId;
            Storage? manufacturedPartStorage = await _context.Storages.FirstOrDefaultAsync(s => s.PartId == receipt.ManufacturedPartId && s.FactoryId == factoryId);
            Storage? part1Storage = await _context.Storages.FirstOrDefaultAsync(s => s.PartId == receipt.Material1PartId && s.FactoryId == factoryId);
            Storage? part2Storage = await _context.Storages.FirstOrDefaultAsync(s => s.PartId == receipt.Material2PartId && s.FactoryId == factoryId);
            Storage? part3Storage = await _context.Storages.FirstOrDefaultAsync(s => s.PartId == receipt.Material3PartId && s.FactoryId == factoryId);
            Storage? part4Storage = await _context.Storages.FirstOrDefaultAsync(s => s.PartId == receipt.Material4PartId && s.FactoryId == factoryId);

            if (manufacturedPartStorage == null)
            {
                machine.Status = MachineStatus.ERROR;
                await Save();
                throw new ApiException(404, $"Склада для \"{receipt.ManufacturedPart.Name}\" не существует.");
            }
            else if (part1Storage == null)
            {
                machine.Status = MachineStatus.ERROR;
                await Save();
                throw new ApiException(404, $"Склада для \"{receipt.Material1Part.Name}\" не существует.");
            }
            else if (part2Storage == null)
            {
                machine.Status = MachineStatus.ERROR;
                await Save();
                throw new ApiException(404, $"Склада для \"{receipt.Material2Part.Name}\" не существует.");
            }
            else if (part3Storage == null)
            {
                machine.Status = MachineStatus.ERROR;
                await Save();
                throw new ApiException(404, $"Склада для \"{receipt.Material3Part.Name}\" не существует.");
            }
            else if (part4Storage == null)
            {
                machine.Status = MachineStatus.ERROR;
                await Save();
                throw new ApiException(404, $"Склада для \"{receipt.Material4Part.Name}\" не существует.");
            }

            if (receipt.ProductionType == MachineTypes.CONSTRUCTOR)
            {
                int requiredPart1 = receipt.Material1Count;

                if (part1Storage.Count - requiredPart1 < 0)
                {
                    machine.Status = MachineStatus.WAITING;
                    await Save();
                    throw new ApiException(403, $"На складе недостаточно \"{receipt.Material1Part.Name}\".");
                }

                part1Storage.Count -= requiredPart1;
            }

            else if (receipt.ProductionType == MachineTypes.ASSEMBLER)
            {
                int requiredPart1 = receipt.Material1Count;
                int requiredPart2 = receipt.Material2Count;

                if (part1Storage.Count - requiredPart1 < 0)
                {
                    machine.Status = MachineStatus.WAITING;
                    await Save();
                    throw new ApiException(403, $"На складе недостаточно \"{receipt.Material1Part.Name}\".");
                }
                if (part2Storage.Count - requiredPart2 < 0)
                {
                    machine.Status = MachineStatus.WAITING;
                    await Save();
                    throw new ApiException(403, $"На складе недостаточно \"{receipt.Material2Part.Name}\".");
                }

                part1Storage.Count -= requiredPart1;
                part2Storage.Count -= requiredPart2;
            }

            else if (receipt.ProductionType == MachineTypes.MANUFACTURER)
            {
                int requiredPart1 = receipt.Material1Count;
                int requiredPart2 = receipt.Material2Count;
                int requiredPart3 = receipt.Material3Count;
                int requiredPart4 = receipt.Material4Count;

                if (part1Storage.Count - requiredPart1 < 0)
                {
                    machine.Status = MachineStatus.WAITING;
                    await Save();
                    throw new ApiException(403, $"На складе недостаточно \"{receipt.Material1Part.Name}\".");
                }
                if (part2Storage.Count - requiredPart2 < 0)
                {
                    machine.Status = MachineStatus.WAITING;
                    await Save();
                    throw new ApiException(403, $"На складе недостаточно \"{receipt.Material2Part.Name}\".");
                }
                if (part3Storage.Count - requiredPart3 < 0)
                {
                    machine.Status = MachineStatus.WAITING;
                    await Save();
                    throw new ApiException(403, $"На складе недостаточно \"{receipt.Material3Part.Name}\".");
                }
                if (part4Storage.Count - requiredPart4 < 0)
                {
                    machine.Status = MachineStatus.WAITING;
                    await Save();
                    throw new ApiException(403, $"На складе недостаточно \"{receipt.Material4Part.Name}\".");
                }

                part1Storage.Count -= requiredPart1;
                part2Storage.Count -= requiredPart2;
                part3Storage.Count -= requiredPart3;
                part4Storage.Count -= requiredPart4;
            }

            if (manufacturedPartStorage.Count + 1 > manufacturedPartStorage.Max)
            {
                machine.Status = MachineStatus.WAITING;
                await Save();
                throw new ApiException(403, "Склад готовых деталей переполнен.");
            }

            machine.Status = MachineStatus.PROCESSING;
            await Save();
            await Task.Delay(60 / receipt.ProductionRate * 1000);
            manufacturedPartStorage.Count += 1;
            machine.Status = MachineStatus.WAITING;
            await Save();
        }

        public async Task Manufacturing()
        {
            List<Machine> machines = await _context.Machines
                .Where(m => m.Status != MachineStatus.PROCESSING)
                .OrderBy(m => m.Id)
                .ToListAsync();
            foreach (Machine machine in machines)
            {
                try
                {
                    await Task.Run(async () => await MakeCycleAsync(machine.Id));
                }
                catch (ApiException exc)
                {
                    Console.WriteLine($"[{DateTime.Now} | MANUFACTURING] {exc.Message}");
                }
            }
        }

        private async Task Save()
        {
            //int result = await _context.SaveChangesAsync();
            //if (result == 0)
            //    throw new ApiUnexpectedException();
            await _context.SaveChangesAsync();
        }
    }
}
