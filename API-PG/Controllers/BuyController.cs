using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_PG.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
    public class BuyController: ControllerBase
    {
        public IBaseService<Buy> Service {get;}
        public IMapper Mapper {get;}
        public BuyController(IBaseService<Buy> service,IMapper mapper)
        {
            this.Mapper = mapper;
            this.Service = service;
        }
          [HttpGet]
          public async Task<IActionResult> Get()
        {
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<BuyModel[]>(entity);
            return Ok(entity);
        }
        [HttpGet ("{BuyId}")]
        public async Task<IActionResult>GetById(string BuyId)
        {
            var entity = await this.Service.GetById(BuyId);
            var results = this.Mapper.Map<BuyModel>(entity);
            return Ok(entity);
        }


       [HttpPost]
        public async Task<IActionResult> Post(BuyModel buy)
        {

            var buy1 = this.Mapper.Map<Buy>(buy);
           

            this.Service.Add(buy1);

            if (await this.Service.SaveChangesAsync())
                return Created($"api/Buy/{buy.Id}", buy);
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
         public async Task<IActionResult> Put(string Id, BuyModel model)
         {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if(await this.Service.SaveChangesAsync())
          
            return Created($"api/Buy/{model.Id}", this.Mapper.Map<BuyModel>(entity));
            return BadRequest();
         }  
    }
}