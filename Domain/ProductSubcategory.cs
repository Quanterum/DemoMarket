using System.Collections.Generic;
using Domain.Common;

namespace Domain
{
    public class ProductSubcategory : BaseEntity
    {
        public ProductCategory Category { get; set; }
        public List<Product> Products { get; set; }
    }
}