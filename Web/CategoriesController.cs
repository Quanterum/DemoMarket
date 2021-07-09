using System.Threading.Tasks;
using Application.Categories.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace Web
{
    [ApiVersion("1.0")]
    public class CategoriesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Create(CreateCategory command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}