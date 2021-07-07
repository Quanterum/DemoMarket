using System.Threading;
using System.Threading.Tasks;
using Application.Common.CustomExceptions;
using Application.Common.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Commands.Delete
{
    public class DeleteProduct : IRequest
    {
        public DeleteProduct(int id)
        {
            Id = id;
        }

        internal int Id { get; }
    }

    internal class DeleteProductHandler : IRequestHandler<DeleteProduct>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                          ?? throw new NotFoundEntityException(nameof(Product), request.Id);
            product.Delete();
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}