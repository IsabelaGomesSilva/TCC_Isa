using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_PG.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    
    public class ProviderController : ControllerBase
    {
         public IBaseService<Provider> Service { get; }
        public IMapper Mapper { get; }

        public ProviderController(IBaseService<Provider> service,IMapper mapper){
            Service = service;
            Mapper = mapper;
        }
         [HttpGet]
        public async Task<IActionResult> Get(){
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<Provider[]>(entity);
            return Ok(results);
        }

         [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetById(string ProviderId){
            var entity = await this.Service.GetById(ProviderId);
            var results = this.Mapper.Map<Provider>(entity);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProviderModel provider){
            var Prov = this.Mapper.Map<Provider>(provider);
            this.Service.Add(Prov);

            if(await this.Service.SaveChangesAsync())
                return Created($"api/Provider/{provider.Id}",provider);
            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string Id) 
         {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
            this.Service.Delete(entity);

            if (await this.Service.SaveChangesAsync())
            return Ok();
            return BadRequest();   
         }

         [HttpPut("{Id}")]
         public async Task<IActionResult> Put(string Id, ProviderModel model){
            var entity = await this.Service.GetById(Id);

           if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if(await this.Service.SaveChangesAsync())
          
            return Created($"api/Provider/{model.Id}", this.Mapper.Map<ProviderModel>(entity));
            return BadRequest();
         }

       
    }
}