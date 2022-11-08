using JustBlog.Model.Common;
using JustBlog.Model.Tags;
using JustBlog.Services.Tags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService tagServices;
        public TagController(ITagService tagServices)
        {
            this.tagServices = tagServices;
        }
        [HttpGet]
        [Authorize(Roles = "User, Blog Owner, Contributor")]
        public async Task<ActionResult<List<TagVM>>> Get([FromQuery] int? page, [FromQuery] int? pageSize)
        {
            IEnumerable<TagVM> categories = await tagServices.GetAsync(page, pageSize);
            return Ok(categories);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "User, Blog Owner, Contributor")]
        public async Task<ActionResult<List<TagVM>>> GetById(Guid id)
        {
            TagVM? categories = await tagServices.FirstOrDefaultAsync(c => c.Id == id);
            return categories == null ? (ActionResult<List<TagVM>>)BadRequest() : (ActionResult<List<TagVM>>)Ok(categories);
        }
        [HttpPost]
        [Authorize(Roles = "Blog Owner, Contributor")]
        public async Task<ActionResult> Create([FromBody] TagCM TagCM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await tagServices.AddAsync(TagCM);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Have error");
            }
        }
        [HttpPut]
        [Authorize(Roles = "Blog Owner, Contributor")]
        public async Task<ActionResult> Update([FromBody] TagUM TagUM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await tagServices.UpdateAsync(TagUM);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Have error");
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Blog Owner,Contributor")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await tagServices.DeleteAsync(id);
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
            IEnumerable<Select> tags = await tagServices.GetToSelectAsync(page, pageSize);
            return Ok(tags);
        }
    }
}
