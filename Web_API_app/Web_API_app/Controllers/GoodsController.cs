using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API_app.Models;

namespace Web_API_app.Controllers
{
    public class GoodsController : ApiController
    {
        IService GoodService;
        public GoodsController(IService serv)
        {
            GoodService = serv;
        }
       
        // GET api/<controller>
        public IEnumerable<Good> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GoodDTO, Good>()).CreateMapper();
            var goods = mapper.Map<IEnumerable<GoodDTO>, List<Good>>(GoodService.GetGoods());
            return goods;

        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}