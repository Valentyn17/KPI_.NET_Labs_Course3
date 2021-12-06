using AutoMapper;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_API_app.Models;

namespace Web_API_app.Configuration
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