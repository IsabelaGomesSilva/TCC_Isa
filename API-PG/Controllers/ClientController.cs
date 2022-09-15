using AutoMapper;
using Domain.Interfaces;
using Domain.Entity;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_PG.Controllers
{
     [ApiController]
     [Route("api/[controller]")]

    public class ClientController : ControllerBase
    {
        public IBaseService<Client> Service {get;}
        public IMapper Mapper {get;}
        public ClientController(IBaseService<Client> service,IMapper mapper)
        {
            this.Mapper = mapper;
            this.Service = service;
        }
          [HttpGet]
          public async Task<IActionResult> Get()
        {
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<ClientModel[]>(entity);
            return Ok(entity);
        }
          [HttpGet ("{ClientId}")]
        public async Task<IActionResult>GetById(string ClientId)
        {
            var entity = await this.Service.GetById(ClientId);
            var results = this.Mapper.Map<ClientModel>(entity);
            return Ok(entity);
        }


       [HttpPost]
        public async Task<IActionResult> Post(ClientModel client)
        {

            var client1 = this.Mapper.Map<Client>(client);
           

            this.Service.Add(client1);

            if (await this.Service.SaveChangesAsync())
                return Created($"api/Client/{client.Id}", client);
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
         public async Task<IActionResult> Put(string Id, ClientModel model)
         {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if(await this.Service.SaveChangesAsync())
          
            return Created($"api/Client/{model.Id}", this.Mapper.Map<ClientModel>(entity));
            return BadRequest();
         }  
    }
}