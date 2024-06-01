using AutoMapper;
using SmallFactory.DTOs;
using SmallFactory.Models;

namespace SmallFactory.Utils
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Factory, FactoryDto>();

            CreateMap<ProductionChain, ProductionChainDto>();

            CreateMap<Machine, MachineDto>();

            CreateMap<Receipt, ReceiptDto>();

            CreateMap<Part, PartDto>();

            CreateMap<Storage, StorageDto>();

            CreateMap<ShopItem, ShopItemDto>();
        }
    }
}
