using System.Collections.Generic;

namespace Application.Products.Commands
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public float Rating { get; set; }
        public List<string> Photos { get; set; }
    }
}