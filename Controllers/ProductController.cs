using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crudef.Data;
using crudef.Models;

namespace crudef.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase 
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>>Get([FromServices] DataContext context)
        {
            var products = await context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById(
            [FromServices] DataContext context,
            int id)
        {
           var product = await context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id ); 
            return product;
        }
    }

}