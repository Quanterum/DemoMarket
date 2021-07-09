using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products.Commands.Create;
using Application.Products.Commands.Delete;
using Application.Products.Commands.Update;
using Application.Products.Dto;
using Application.Products.Queries.GetProductsByFilter;
using Microsoft.AspNetCore.Mvc;

namespace Web
{
    [ApiVersion("1.0")]
    public class ProductController : BaseController
    {
        public async Task<List<ProductListDto>> GetProductsByFilter([FromQuery] GetProductsByFilter filter) 
            => await Mediator.Send(filter);

        [HttpPost]
        public async Task<ActionResult> Create(CreateProduct command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateProduct command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProduct(id));
            return Ok();
        }
    }
}