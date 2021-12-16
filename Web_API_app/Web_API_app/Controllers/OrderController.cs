using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API_app.App_Start;
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
            try
            {
                var imapper = AutoMapperConfiguration.GetMapper();
                var order = imapper.Map<OrderDTO, Order>(OrderService.GetOrder(id));

                return Ok(order);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            }

        // POST api/<controller>
        public HttpResponseMessage Post(string email, int count, int goodId)
        {
            if (!ModelState.IsValid)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            Order order = new Order { Email = email, Count = count, GoodId = goodId };
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
        public IHttpActionResult Put([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order can't be null");
            }
            if (!ModelState.IsValid) {
                return BadRequest("Model is not valid");
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