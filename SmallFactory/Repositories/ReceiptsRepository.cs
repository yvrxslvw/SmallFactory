using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Repositories
{
    public class ReceiptsRepository(AppDbContext context) : IReceiptsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Receipt> CreateReceiptAsync(CreateReceiptDto createReceiptDto)
        {
            if (!(await IsPartExists(createReceiptDto.ResultPartId)))
                throw new ApiException(404, "Детали для производимого материала не существует.");
            if (!(await IsPartExists(createReceiptDto.Material1Id)))
                throw new ApiException(404, "Детали для материала 1 не существует.");
            if (!(await IsPartExists(createReceiptDto.Material2Id)))
                throw new ApiException(404, "Детали для материала 2 не существует.");
            if (!(await IsPartExists(createReceiptDto.Material3Id)))
                throw new ApiException(404, "Детали для материала 3 не существует.");
            if (!(await IsPartExists(createReceiptDto.Material4Id)))
                throw new ApiException(404, "Детали для материала 4 не существует.");
            if (createReceiptDto.ProductionRate < 1)
                throw new ApiException(400, "Некорректное количество деталей в минуту.");
            if (createReceiptDto.Material1Count < 1)
                throw new ApiException(400, "Некорректное количество первого материала.");
            if (createReceiptDto.Material2Count < 1)
                throw new ApiException(400, "Некорректное количество второго материала.");
            if (createReceiptDto.Material3Count < 1)
                throw new ApiException(400, "Некорректное количество третьего материала.");
            if (createReceiptDto.Material4Count < 1)
                throw new ApiException(400, "Некорректное количество четвёртого материала.");
            Receipt receipt = new Receipt()
            {
                ProductionType = (MachineTypes)createReceiptDto.ProductionType,
                ManufacturedPartId = createReceiptDto.ResultPartId,
                Material1PartId = createReceiptDto.Material1Id,
                Material2PartId = createReceiptDto.Material2Id,
                Material3PartId = createReceiptDto.Material3Id,
                Material4PartId = createReceiptDto.Material4Id,
                ProductionRate = createReceiptDto.ProductionRate,
                Material1Count = createReceiptDto.Material1Count,
                Material2Count = createReceiptDto.Material2Count,
                Material3Count = createReceiptDto.Material3Count,
                Material4Count = createReceiptDto.Material4Count,
            };
            _context.Receipts.Add(receipt);
            await Save();
            return receipt;
        }

        public async Task DeleteReceiptAsync(int id)
        {
            Receipt? receipt = await _context.Receipts
                .Include(r => r.ManufacturedPart)
                .Include(r => r.Material1Part)
                .Include(r => r.Material2Part)
                .Include(r => r.Material3Part)
                .Include(r => r.Material4Part)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (receipt == null)
                throw new ApiException(404, "Рецепта с таким ID не существует.");
            _context.Receipts.Remove(receipt);
            await Save();
        }

        public async Task<Receipt> GetReceiptByIdAsync(int id)
        {
            Receipt? receipt = await _context.Receipts
                .Include(r => r.ManufacturedPart)
                .Include(r => r.Material1Part)
                .Include(r => r.Material2Part)
                .Include(r => r.Material3Part)
                .Include(r => r.Material4Part)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (receipt == null)
                throw new ApiException(404, "Рецепта с таким ID не существует.");
            return receipt;
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsAsync()
        {
            List<Receipt> receipts = await _context.Receipts
                .Include(r => r.ManufacturedPart)
                .Include(r => r.Material1Part)
                .Include(r => r.Material2Part)
                .Include(r => r.Material3Part)
                .Include(r => r.Material4Part)
                .OrderBy(r => r.Id)
                .ToListAsync();
            return receipts;
        }

        public async Task<Receipt> UpdateReceiptAsync(int id, UpdateReceiptDto updateReceiptDto)
        {
            Receipt? receipt = await _context.Receipts
                .Include(r => r.ManufacturedPart)
                .Include(r => r.Material1Part)
                .Include(r => r.Material2Part)
                .Include(r => r.Material3Part)
                .Include(r => r.Material4Part)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (receipt == null)
                throw new ApiException(404, "Рецепта с таким ID не существует.");
            if (updateReceiptDto.ProductionType != null)
            {
                receipt.ProductionType = (MachineTypes)updateReceiptDto.ProductionType;
            }
            if (updateReceiptDto.ResultPartId != null)
            {
                int partId = (int)updateReceiptDto.ResultPartId;
                if (!(await IsPartExists(partId)))
                    throw new ApiException(404, "Детали для производимого материала не существует.");
                receipt.ManufacturedPartId = partId;
            }
            if (updateReceiptDto.Material1Id != null)
            {
                int partId = (int)updateReceiptDto.Material1Id;
                if (!(await IsPartExists(partId)))
                    throw new ApiException(404, "Детали для материала 1 не существует.");
                receipt.Material1PartId = partId;
            }
            if (updateReceiptDto.Material2Id != null)
            {
                int partId = (int)updateReceiptDto.Material2Id;
                if (!(await IsPartExists(partId)))
                    throw new ApiException(404, "Детали для материала 2 не существует.");
                receipt.Material2PartId = partId;
            }
            if (updateReceiptDto.Material3Id != null)
            {
                int partId = (int)updateReceiptDto.Material3Id;
                if (!(await IsPartExists(partId)))
                    throw new ApiException(404, "Детали для материала 3 не существует.");
                receipt.Material3PartId = partId;
            }
            if (updateReceiptDto.Material4Id != null)
            {
                int partId = (int)updateReceiptDto.Material4Id;
                if (!(await IsPartExists(partId)))
                    throw new ApiException(404, "Детали для материала 4 не существует.");
                receipt.Material4PartId = partId;
            }
            if (updateReceiptDto.ProductionRate != null)
            {
                receipt.ProductionRate = (int)updateReceiptDto.ProductionRate;
            }
            await Save();
            return receipt;
        }

        private async Task Save()
        {
            int result = await _context.SaveChangesAsync();
            if (result == 0)
                throw new ApiUnexpectedException();
        }

        private async Task<bool> IsPartExists(int partId)
        {
            Part? part = await _context.Parts.FirstOrDefaultAsync(p => p.Id == partId);
            if (part == null) return false;
            else return true;
        }
    }
}
