using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Model;
using AssetManagement.DTO;
namespace AssetManagement
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Asset, AssetDTO>().ReverseMap();
            CreateMap<CustomerAsset, CustomerAssetDTO>().ReverseMap();
            CreateMap<Login, LoginDTO>().ReverseMap();
        }
    }
}
