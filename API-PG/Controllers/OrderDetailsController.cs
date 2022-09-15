

using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_PG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        public IBaseService<OrderDetails> Service { get; }
        public IMapper Mapper { get; }
        public OrderDetailsController(IBaseService<OrderDetails> service,IMapper mapper){
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<OrderDetails[]>(entity);
            return Ok(results);
        }

        [HttpGet("{OrderDetailsId}")]
        public async Task<IActionResult> GetById(string OrderDetailsId){
            var entity = await this.Service.GetById(OrderDetailsId);
            var results = this.Mapper.Map<OrderDetails>(entity);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderDetailsModel orderDetails){
            var OrdDet = this.Mapper.Map<OrderDetails>(orderDetails);
            this.Service.Add(OrdDet);

            if(await this.Service.SaveChangesAsync())
                return Created($"api/OrderDetails/{orderDetails.Id}",orderDetails);
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
         public async Task<IActionResult> Put(string Id, OrderDetailsModel model){
            var entity = await this.Service.GetById(Id);

           if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if(await this.Service.SaveChangesAsync())
          
            return Created($"api/OrderDetails/{model.Id}", this.Mapper.Map<OrderDetailsModel>(entity));
            return BadRequest();
         }
        
    }
}