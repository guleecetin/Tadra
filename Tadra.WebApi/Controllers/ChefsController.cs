using Microsoft.AspNetCore.Mvc;
using Tadra.WebApi.Context;
using Tadra.WebApi.Entities;

namespace Tadra.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext apiContext)
        {
           _context = apiContext;
        }
        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Şef sisteme başarıyla eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value=_context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Şef sistemden silindi");
            
        }
        [HttpGet("GetChef")]
        public IActionResult GetChef(int id)
        {
            var value = _context.Chefs.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Bilgiler başarılı şekilde güncellendi");
        }
    }
}
