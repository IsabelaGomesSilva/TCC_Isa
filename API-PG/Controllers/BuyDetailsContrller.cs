using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_PG.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
    public class BuyDetailsContrller: ControllerBase
    {
        public IBaseService<BuyDetails> Service {get;}
        public IMapper Mapper {get;}
        public BuyDetailsContrller(IBaseService<BuyDetails> service,IMapper mapper)
        {
            this.Mapper = mapper;
            this.Service = service;
        }
          [HttpGet]
          public async Task<IActionResult> Get()
        {
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<BuyDetailsModel[]>(entity);
            return Ok(entity);
        }
        [HttpGet ("{BuyDetailsId}")]
        public async Task<IActionResult>GetById(string BuyId)
        {
            var entity = await this.Service.GetById(BuyId);
            var results = this.Mapper.Map<BuyDetailsModel>(entity);
            return Ok(entity);
        }


       [HttpPost]
        public async Task<IActionResult> Post(BuyDetailsModel buydetails)
        {

            var buydetails1 = this.Mapper.Map<BuyDetails>(buydetails);
           

            this.Service.Add(buydetails1);

            if (await this.Service.SaveChangesAsync())
                return Created($"api/BuyDetails/{buydetails.Id}", buydetails);
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
         public async Task<IActionResult> Put(string Id, BuyDetailsModel model)
         {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if(await this.Service.SaveChangesAsync())
          
            return Created($"api/BuyDetails/{model.Id}", this.Mapper.Map<BuyDetailsModel>(entity));
            return BadRequest();
         }  
    }
}