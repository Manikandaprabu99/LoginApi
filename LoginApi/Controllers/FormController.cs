using Microsoft.AspNetCore.Cors;
using LoginApi.Data;
using LoginApi.Models;
using LoginApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace LoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly APIDbContext dbContext;

        public FormController(APIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForms()
        {
            var forms = await dbContext.Forms.ToListAsync();

            return Ok(forms);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetFormById")]
        public async Task<IActionResult> GetFormById(Guid id)
        {
            var form = await dbContext.Forms.FirstOrDefaultAsync(x => x.Id == id);
            if(form != null)
            {
                return Ok(form);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddForm(AddFormRequest addFormRequest)
        {
            var form = new Form()
            {
                Name = addFormRequest.Name,
                MobileNumber = addFormRequest.MobileNumber,
                Gender = addFormRequest.Gender,
                Course = addFormRequest.Course

            };
            await dbContext.Forms.AddAsync(form);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteForm(Guid id)
        {
            var existingForm = await dbContext.Forms.FindAsync(id);

            if(existingForm != null)
            {
                dbContext.Remove(existingForm);
                await dbContext.SaveChangesAsync();
                return Ok(existingForm);
            }
            return NotFound();
        }


        [HttpPost("AdminLogin")]
        public IActionResult AdminLogin(AdminDetails Admin)
        {
            var userAvailable = dbContext.AdminDetail.Where(u => u.Email == Admin.Email && u.Pwd == Admin.Pwd).FirstOrDefault();
            if (userAvailable != null)
            {
                return Ok("success");
            }
            return Ok("Failure");

        }
    }
}
