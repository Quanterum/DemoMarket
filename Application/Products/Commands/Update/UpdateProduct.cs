using System.Threading;
using System.Threading.Tasks;
using Application.Common.CustomExceptions;
using Application.Common.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Commands.Update
{
    public class UpdateProduct : ProductRequest, IRequest
    {
        public int Id { get; set; }
    }

    internal class UpdateProductHandler : IRequestHandler<UpdateProduct>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                          ?? throw new NotFoundEntityException(nameof(Product), request.Id);
            product.Rename(request.Name);
            product.Update(request.Description, request.Price, request.Count, request.Rating, request.Photos);
            return Unit.Value;
        }
    }
}