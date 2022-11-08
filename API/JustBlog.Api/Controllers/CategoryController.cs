using JustBlog.Model.Categories;
using JustBlog.Model.Common;
using JustBlog.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryServices;
        public CategoryController(ICategoryService categoryServices)
        {
            this.categoryServices = categoryServices;
        }
        [HttpGet]
        [Authorize(Roles = "User, Blog Owner, Contributor")]
        public async Task<ActionResult<List<CategoryVM>>> Get([FromQuery] int? page, [FromQuery] int? pageSize)
        {
            IEnumerable<CategoryVM> categories = await categoryServices.GetAsync(page, pageSize);
            return Ok(categories);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "User, Blog Owner, Contributor")]
        public async Task<ActionResult<List<CategoryVM>>> GetById(Guid id)
        {
            CategoryVM? categories = await categoryServices.FirstOrDefaultAsync(c => c.Id == id);
            return categories == null ? (ActionResult<List<CategoryVM>>)BadRequest() : (ActionResult<List<CategoryVM>>)Ok(categories);
        }
        [HttpPost]
        [Authorize(Roles = "Blog Owner, Contributor")]
        public async Task<ActionResult> Create([FromBody] CategoryCM categoryCM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await categoryServices.AddAsync(categoryCM);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Have error");
            }
        }
        [HttpPut]
        [Authorize(Roles = "Blog Owner, Contributor")]
        public async Task<ActionResult> Update([FromBody] CategoryUM categoryUM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await categoryServices.UpdateAsync(categoryUM);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Have error");
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Blog Owner")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await categoryServices.DeleteAsync(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest("Have error");
            }
        }
        [HttpGet("Get-to-select")]
        [Authorize(Roles = "Blog Owner, Contributor")]
        public async Task<ActionResult<IEnumerable<Select>>> GetToSelect([FromQuery] int? page, [FromQuery] int? pageSize)
        {
            IEnumerable<Select> tags = await categoryServices.GetToSelectAsync(page, pageSize);
            return Ok(tags);
        }
    }

}
