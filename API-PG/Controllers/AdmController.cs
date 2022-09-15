
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Infra.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_PG.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
    public class AdmController : ControllerBase
    {
        public IBaseService<Adm> Service {get;}
        public IMapper Mapper {get;}
        public AdmController(IBaseService<Adm> service,IMapper mapper)
        {
            this.Mapper = mapper;
            this.Service = service;
        }
          [HttpGet]
          public async Task<IActionResult> Get()
        {
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<AdmModel[]>(entity);
            return Ok(entity);
        }
        [HttpGet ("{AdmId}")]
        public async Task<IActionResult>GetById(string AdmId)
        {
            var entity = await this.Service.GetById(AdmId);
            var results = this.Mapper.Map<AdmModel>(entity);
            return Ok(entity);
        }


       [HttpPost]
        public async Task<IActionResult> Post(AdmModel adm)
        {

            var adm1 = this.Mapper.Map<Adm>(adm);
           

            this.Service.Add(adm1);

            if (await this.Service.SaveChangesAsync())
                return Created($"api/Adm/{adm.Id}", adm);
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
         public async Task<IActionResult> Put(string Id, AdmModel model)
         {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if(await this.Service.SaveChangesAsync())
          
            return Created($"api/Adm/{model.Id}", this.Mapper.Map<AdmModel>(entity));
            return BadRequest();
         }  
    }
}