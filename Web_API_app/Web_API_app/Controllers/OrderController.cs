using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API_app.Configuration;
using Web_API_app.Models;

namespace Web_API_app.Controllers
{
    public class OrderController : ApiController
    {
        IService OrderService;
        public OrderController(IService serv)
        {
            OrderService = serv;
        }
        // GET api/<controller>
        public IEnumerable<Order> Get()
        {
            var imapper = AutoMapperConfiguration.GetMapper();
            var orders = imapper.Map<IEnumerable<OrderDTO>, List<Order>>(OrderService.GetOrders());
            return orders;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var imapper = AutoMapperConfiguration.GetMapper();
            var order = imapper.Map<OrderDTO, Order>(OrderService.GetOrder(id));
            if (order == null) { return NotFound(); }
            return Ok(order);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] Order order)
        {
            var imapper = AutoMapperConfiguration.GetMapper();
            var orderDTO = imapper.Map<Order, OrderDTO>(order);
            try
            {
                OrderService.MakeOrder(orderDTO);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order can't be null");
            }
            try
            {
                var mapper = AutoMapperConfiguration.GetMapper();
                var orderDTO = mapper.Map<Order, OrderDTO>(order);
                OrderService.ChangeOrderStatus(orderDTO);
                return Ok(order);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                OrderService.DeleteOrder(id);
                return Ok();
            }
            catch(InvalidOperationException ex) {
               return BadRequest(ex.Message);
            }
        }
    }
}