using Web_API_app.App_Start;
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
            var mapper = AutoMapperConfiguration.GetMapper();
            var goods = mapper.Map<IEnumerable<GoodDTO>, List<Good>>(GoodService.GetGoods());
            return goods;

        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var mapper = AutoMapperConfiguration.GetMapper();
            var good = mapper.Map<GoodDTO, Good>(GoodService.GetGood(id));
            if (good == null) { return NotFound(); }
            return Ok(good);
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Good good)
        {
            var mapper = AutoMapperConfiguration.GetMapper();
            var goodDTO = mapper.Map<Good, GoodDTO>(good);
            try
            {
                GoodService.CreateGood(goodDTO);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch {
                return  new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody] Good good)
        {
            if (good == null)
            {
                return BadRequest();
            }
            var mapper = AutoMapperConfiguration.GetMapper();
            var goodDTO = mapper.Map<Good, GoodDTO>(good);
            GoodService.UpdateGood(goodDTO); 
            return Ok(good);
        }

        
        [HttpDelete]
        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                GoodService.DeleteGood(id);
                return Ok(id);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}