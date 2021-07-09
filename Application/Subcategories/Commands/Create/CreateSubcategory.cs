using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Subcategories.Commands.Create
{
    public class CreateSubcategory : IRequest
    {
        public string Name { get; set; }
    }

    internal class CreateSubcategoryHandler : IRequestHandler<CreateSubcategory>
    {
        private readonly IApplicationDbContext _context;
        
        public CreateSubcategoryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateSubcategory request, CancellationToken cancellationToken)
        {
            var searchResult =
                await _context.Subcategories.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (searchResult) throw new Exception("Already Exists!");
            
            var subcategory = new ProductSubcategory {Name = request.Name};
            await _context.Subcategories.AddAsync(subcategory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}