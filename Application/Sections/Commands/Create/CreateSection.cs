using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sections.Commands.Create
{
    public class CreateSection : IRequest
    {
        public string Name { get; set; }
    }

    internal class CreateSectionHandler : IRequestHandler<CreateSection>
    {
        private readonly IApplicationDbContext _context;

        public CreateSectionHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateSection request, CancellationToken cancellationToken)
        {
            var searchResult = await _context.Sections.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (searchResult) throw new Exception("Already Exists!");

            var section = new Section {Name = request.Name};
            await _context.Sections.AddAsync(section, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}