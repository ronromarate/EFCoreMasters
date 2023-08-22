using AutoMapper;
using InventoryAppEFCore.DataLayer.EfClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.Services
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.ProductName, m => m.MapFrom(s => s.Name));
        }
    }
}
