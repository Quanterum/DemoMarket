using System.Collections.Generic;
using Domain.Common;
using Domain.Common.Interfaces;

namespace Domain
{
    public class ProductCategory : BaseEntity, ICategory
    {
        public List<ProductSubcategory> Subcategories { get; set; }
    }
}