using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Products.Commands.Create
{
    public class CreateProduct : ProductRequest, IRequest
    {
        public int SubcategoryId { get; set; }
    }

    public class CreateProductHandler : IRequestHandler<CreateProduct>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductHandler(IApplicationDbContext context) => _context = context;

        public async Task<Unit> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            Product product = new(request.Name, request.Description, request.Price, request.Count, request.Rating, 
                request.Photos, request.SubcategoryId);
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}