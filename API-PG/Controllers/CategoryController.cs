using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Infra.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_PG.Controllers
{
     [ApiController]
     [Route("api/[controller]")]

    public class CategoryController : ControllerBase
    {
        public IBaseService<Category> Service {get;}
        public IMapper Mapper {get;}
        public CategoryController(IBaseService<Category> service,IMapper mapper)
        {
            this.Mapper = mapper;
            this.Service = service;
        }
          [HttpGet]
          public async Task<IActionResult> Get()
        {
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<CategoryModel[]>(entity);
            return Ok(entity);
        }
          [HttpGet ("{CategoryId}")]
        public async Task<IActionResult>GetById(string CategoryId)
        {
            var entity = await this.Service.GetById(CategoryId);
            var results = this.Mapper.Map<CategoryModel>(entity);
            return Ok(entity);
        }


       [HttpPost]
        public async Task<IActionResult> Post(CategoryModel category)
        {

            var category1 = this.Mapper.Map<Category>(category);
           

            this.Service.Add(category1);

            if (await this.Service.SaveChangesAsync())
                return Created($"api/Category/{category.Id}", category);
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
         public async Task<IActionResult> Put(string Id, CategoryModel model)
         {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if(await this.Service.SaveChangesAsync())
          
            return Created($"api/Category/{model.Id}", this.Mapper.Map<CategoryModel>(entity));
            return BadRequest();
         }  
    }
}