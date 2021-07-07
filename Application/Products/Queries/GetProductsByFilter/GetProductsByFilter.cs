using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Products.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilter : IRequest<List<ProductListDto>>
    {
        public int Page { get; set; }
        public int Take { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int? Count { get; set; }
        public float? Rating { get; set; }
        public bool WithPhotosOnly { get; set; }
    }

    internal class GetProductsByFilterHandler : IRequestHandler<GetProductsByFilter, List<ProductListDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        internal GetProductsByFilterHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetProductsByFilter request, CancellationToken cancellationToken)
        {
            var query = _context.Products.AsQueryable();
            return await ApplyFilter(query, request)
                .ExecutePageFilter(request.Page, request.Take)
                .ProjectTo<ProductListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        private static IQueryable<Product> ApplyFilter(IQueryable<Product> query, GetProductsByFilter filter)
        {
            query = query.ExecuteNameFilter(filter.Name);

            if (string.IsNullOrEmpty(filter.Description))
                query = query.Where(x => x.Description.Contains(filter.Description));

            if (filter.Rating.HasValue)
                query = query.Where(x => x.Rating >= filter.Rating);

            if (filter.PriceFrom.HasValue)
                query = query.Where(x => x.Price >= filter.PriceFrom);

            if (filter.PriceTo.HasValue)
                query = query.Where(x => x.Price <= filter.PriceTo);

            if (filter.Count.HasValue)
                query = query.Where(x => x.Count >= filter.Count);

            if (filter.WithPhotosOnly)
                query = query.Where(x => x.Photos.Count > 0);

            return query;
        }
    }
}