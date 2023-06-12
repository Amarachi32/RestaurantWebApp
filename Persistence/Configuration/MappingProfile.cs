using AutoMapper;
using Contracts.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, CreateProductDto>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<GetProductDto, Product>();
        }
    }
}
