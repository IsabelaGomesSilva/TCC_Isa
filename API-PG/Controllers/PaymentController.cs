using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_PG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        public IBaseService<Payment> Service { get; }
        public IMapper Mapper { get; }
         public PaymentController(IBaseService<Payment> service,IMapper mapper){
            Service = service;
            Mapper = mapper;
        }

       [HttpGet]
        public async Task<IActionResult> Get(){
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<Payment[]>(entity);
            return Ok(results);
        }

        [HttpGet("{PaymentId}")]
        public async Task<IActionResult> GetById(string PaymentId){
            var entity = await this.Service.GetById(PaymentId);
            var results = this.Mapper.Map<Payment>(entity);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PaymentModel payment){
            var Pay = this.Mapper.Map<Payment>(payment);
            this.Service.Add(Pay);

            if(await this.Service.SaveChangesAsync())
                return Created($"api/Payment/{payment.Id}",payment);
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
         public async Task<IActionResult> Put(string Id, PaymentModel model){
            var entity = await this.Service.GetById(Id);

           if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if(await this.Service.SaveChangesAsync())
          
            return Created($"api/Payment/{model.Id}", this.Mapper.Map<PaymentModel>(entity));
            return BadRequest();
         }

    }
}