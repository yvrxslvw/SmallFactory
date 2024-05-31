using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Interfaces;
using SmallFactory.Models;
using SmallFactory.Exceptions;

namespace SmallFactory.Repositories
{
    public class PartsRepository(PartsContext partsContext) : IPartsRepository
    {
        private readonly PartsContext _partsContext = partsContext;

        public async Task<Part> CreatePartAsync(CreatePartDto createPartDto)
        {
            if (await IsPartExists(createPartDto.Name))
                throw new ApiException(403, "Деталь с таким именем уже существует.");
            Part part = new Part()
            {
                Name = createPartDto.Name
            };
            _partsContext.Parts.Add(part);
            await Save();
            return part;
        }

        public async Task DeletePartAsync(int id)
        {
            Part? part = await _partsContext.Parts.FirstOrDefaultAsync(p => p.Id == id);
            if (part == null)
                throw new ApiException(404, "Детали с таким ID не существует.");
            _partsContext.Parts.Remove(part);
            await Save();
        }

        public async Task<Part> GetPartByIdAsync(int id)
        {
            Part? part = await _partsContext.Parts.FirstOrDefaultAsync(p => p.Id == id);
            if (part == null)
                throw new ApiException(404, "Детали с таким ID не существует.");
            return part;
        }

        public async Task<IEnumerable<Part>> GetPartsAsync()
        {
            List<Part> parts = await _partsContext.Parts.ToListAsync();
            return parts;
        }

        public async Task<Part> UpdatePartAsync(int id, UpdatePartDto updatePartDto)
        {
            Part? part = await _partsContext.Parts.FirstOrDefaultAsync(p => p.Id == id);
            if (part == null)
                throw new ApiException(404, "Детали с таким ID не существует.");
            if (updatePartDto.Name == part.Name) return part;
            else if (await IsPartExists(updatePartDto.Name))
                throw new ApiException(403, "Деталь с таким именем уже существует.");
            part.Name = updatePartDto.Name;
            await Save();
            return part;
        }

        private async Task<bool> IsPartExists(string name)
        {
            Part? part = await _partsContext.Parts.FirstOrDefaultAsync(p => p.Name == name);
            if (part == null) return false;
            else return true;
        }

        private async Task Save()
        {
            int result = await _partsContext.SaveChangesAsync();
            if (result == 0)
                throw new ApiUnexpectedException();
        }
    }
}
