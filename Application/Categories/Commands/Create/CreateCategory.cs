using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Commands.Create
{
    public class CreateCategory : IRequest
    {
        public string Name { get; set; }
    }

    internal class CreateCategoryHandler : IRequestHandler<CreateCategory>
    {
        private readonly IApplicationDbContext _context;

        public CreateCategoryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            var searchResult =
                await _context.ProductCategories.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (searchResult) throw new Exception("Already Exists!");

            var category = new ProductCategory {Name = request.Name};
            await _context.ProductCategories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}