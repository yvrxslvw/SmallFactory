using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Repositories
{
    public class PartsRepository(AppDbContext context) : IPartsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Part> CreatePartAsync(CreatePartDto createPartDto)
        {
            if (await IsPartExists(createPartDto.Name))
                throw new ApiException(403, "Деталь с таким именем уже существует.");
            Part part = new Part()
            {
                Name = createPartDto.Name
            };
            _context.Parts.Add(part);
            await Save();
            return part;
        }

        public async Task DeletePartAsync(int id)
        {
            Part? part = await _context.Parts.FirstOrDefaultAsync(p => p.Id == id);
            if (part == null)
                throw new ApiException(404, "Детали с таким ID не существует.");
            _context.Parts.Remove(part);
            await Save();
        }

        public async Task<Part> GetPartByIdAsync(int id)
        {
            Part? part = await _context.Parts
                .FirstOrDefaultAsync(p => p.Id == id);
            if (part == null)
                throw new ApiException(404, "Детали с таким ID не существует.");
            return part;
        }

        public async Task<IEnumerable<Part>> GetPartsAsync()
        {
            List<Part> parts = await _context.Parts
                .OrderBy(p => p.Id)
                .ToListAsync();
            return parts;
        }

        public async Task<Part> UpdatePartAsync(int id, UpdatePartDto updatePartDto)
        {
            Part? part = await _context.Parts.FirstOrDefaultAsync(p => p.Id == id);
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
            Part? part = await _context.Parts.FirstOrDefaultAsync(p => p.Name == name);
            if (part == null) return false;
            else return true;
        }

        private async Task Save()
        {
            int result = await _context.SaveChangesAsync();
            if (result == 0)
                throw new ApiUnexpectedException();
        }
    }
}
