using System.Threading.Tasks;
using Application.Subcategories.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace Web
{
    [ApiVersion("1.0")]
    public class SubcategoriesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Create(CreateSubcategory command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}