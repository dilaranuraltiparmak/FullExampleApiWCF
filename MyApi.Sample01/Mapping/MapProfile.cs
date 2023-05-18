using AutoMapper;
using MyApi.Sample01.DTO;
using MyApi.Sample01.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Sample01.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            //todo entites to DTO  <=
        }
    }
}
