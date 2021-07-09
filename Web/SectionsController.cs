using System.Threading.Tasks;
using Application.Sections.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace Web
{
    [ApiVersion("1.0")]
    public class SectionsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Create(CreateSection command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}