using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Good, GoodDTO>();
                cfg.CreateMap<GoodDTO, Good>();
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderDTO, Order>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
