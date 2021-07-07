using System.Collections.Generic;
using Application.Common.Interfaces;
using Domain;

namespace Application.Products.Dto
{
    public class ProductDto : IBaseMap<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public float Rating { get; set; }
        public List<string> Photos { get; set; }
    }
}