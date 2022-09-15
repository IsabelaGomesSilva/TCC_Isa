using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_PG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public IBaseService<Product> Service { get; }
        public IMapper Mapper { get; }
         public ProductController(IBaseService<Product> service,IMapper mapper){
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<Product[]>(entity);
            return Ok(results);
        }

         [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetById(string ProductId){
            var entity = await this.Service.GetById(ProductId);
            var results = this.Mapper.Map<Product>(entity);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductModel product){
            var Prod = this.Mapper.Map<Product>(product);
            this.Service.Add(Prod);

            if(await this.Service.SaveChangesAsync())
                return Created($"api/Product/{product.Id}",product);
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
         public async Task<IActionResult> Put(string Id, ProductModel model){
            var entity = await this.Service.GetById(Id);

           if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if(await this.Service.SaveChangesAsync())
          
            return Created($"api/Product/{model.Id}", this.Mapper.Map<ProductModel>(entity));
            return BadRequest();
         }

       
    }
}