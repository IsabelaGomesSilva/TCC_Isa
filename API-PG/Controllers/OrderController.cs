using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_PG.Controllers
{
         [ApiController]
         [Route("api/[controller]")]

      public class OrderController : ControllerBase
     {
        public IBaseService<Order> Service {get;}
        public IMapper Mapper {get;}
        public OrderController(IBaseService<Order> service,IMapper mapper)
        {
            this.Mapper = mapper;
            this.Service = service;
        }
          [HttpGet]
          public async Task<IActionResult> Get()
        {
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<OrderModel[]>(entity);
            return Ok(entity);
        }
          [HttpGet ("{ClientId}")]
        public async Task<IActionResult>GetById(string OrderId)
        {
            var entity = await this.Service.GetById(OrderId);
            var results = this.Mapper.Map<OrderModel>(entity);
            return Ok(entity);
        }


       [HttpPost]
        public async Task<IActionResult> Post(OrderModel order)
        {

            var order1 = this.Mapper.Map<Order>(order);
           

            this.Service.Add(order1);

            if (await this.Service.SaveChangesAsync())
                return Created($"api/Order/{order.Id}", order);
            return BadRequest();
        }

         [HttpDelete("{Id}")]
         public async Task<IActionResult>Delete(string Id) 
         {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
            this.Service.Delete(entity);

            if (await this.Service.SaveChangesAsync())
            return Ok();
            return BadRequest();   
         }

         [HttpPut("{Id}")]
         public async Task<IActionResult> Put(string Id, OrderModel model)
         {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if(await this.Service.SaveChangesAsync())
          
            return Created($"api/Order/{model.Id}", this.Mapper.Map<OrderModel>(entity));
            return BadRequest();
         }  
    }
}